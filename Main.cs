using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using DiffMatchPatch;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;


namespace TextComparer{
    public partial class MainForm : Form {
        //Библиотеки для одновременной прокрутки
        [DllImport("User32.dll")]
        public extern static int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("User32.dll")]
        public extern static int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        public enum ScrollBarType : uint{
            SbHorz = 0,
            SbVert = 1,
            SbCtl = 2,
            SbBoth = 3
        }

        public enum Message : uint{
            WM_VSCROLL = 0x0115,
            WM_HSCROLL = 0x0114
        }

        public enum ScrollBarCommands : uint{
            SB_THUMBPOSITION = 4
        }

        bool leftFileIsLoaded = false;
        bool rightFileIsLoaded = false;

        //Объект diff_match_patch
        diff_match_patch DIFF = new diff_match_patch();

        //Список различий
        List<Diff> diffs;

        //Список частей в RichTextBox для подсветки
        List<Chunk> chunklist1;
        List<Chunk> chunklist2;

        //Список различающихся частей для сохранения в файл
        List<string> outlist1 = new List<string>();
        List<string> outlist2 = new List<string>();

        //Цвета подсветки
        Color[] colors1 = new Color[2] { Color.LightGreen, Color.LightSalmon };
        Color[] colors2 = new Color[2] { Color.LightSalmon, Color.LightGreen };

        int firstFileLength = 0;
        int secondFileLength = 0;

        int firstFileDiffsCount = 0; //Количество различий в первом файле
        int secondFileDiffsCount = 0; //Количество различий во втором файле
        int diffsCount = 0; //Общее количество различий

        int firstFileCharDiffsCount = 0; //Количество различий по символам в первом файле
        int secondFileCharDiffsCount = 0; //Количество различий по символам во втором файле
        int charDiffsCount = 0; //Общее количество различий по символам

        string resultStr; //Строка результата для отображение в RichTextBox сохранения файла


        public struct Chunk{
            public int startpos;
            public int length;
            public Color BackColor;
        }

        public MainForm(){
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //Запретить изменение размера формы
        }

        private void FileLeftButton_Click(object sender, EventArgs e){
            if (OpenFileDialog.ShowDialog() == DialogResult.Cancel) return;
            //Получаем выбранный файл
            string filename = OpenFileDialog.FileName;

            FileInfo fileinfo = new FileInfo(filename);
            
            if (fileinfo.Length == 0) {
                MessageBox.Show(
                             "File is empty",
                             "Error",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                return;
            }

            //Читаем файл в текстовое поле
            string txt = File.ReadAllText(filename);
            string handledTxt = DeleteExcessSpaceCharacters(txt);

            if (handledTxt.Length == 0) {
                MessageBox.Show(
                            "File is empty",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                return;
            }
            
            RichTextBoxLeft.Text = handledTxt;
            firstFileLength = RichTextBoxLeft.Text.Length;
            leftFileIsLoaded = true;


            string[] strParts = filename.Split('\\');
            filename = strParts[strParts.Length - 1];
            LabelFileLeftName.Text = TrunkString(filename);

            RichTextBoxResult.Text = "";

            //Активация кнопки Сравнить, если оба файла загружены
            if (CanCompareFiles(leftFileIsLoaded, rightFileIsLoaded)) {
                CompareButton.Enabled = true;
            }

        }

        private void FileRightButton_Click(object sender, EventArgs e){
            if (OpenFileDialog.ShowDialog() == DialogResult.Cancel) return;
            //Получаем выбранный файл
            string filename = OpenFileDialog.FileName;

            FileInfo fileinfo = new FileInfo(filename);
            if (fileinfo.Length == 0){
                MessageBox.Show(
                             "File is empty",
                             "Error",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                return;
            }

            //Читаем файл в текстовое поле
            string txt = File.ReadAllText(filename);
            string handledTxt = DeleteExcessSpaceCharacters(txt);

            if (handledTxt.Length == 0){
                MessageBox.Show(
                            "File is empty",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                return;
            }

            RichTextBoxRight.Text = handledTxt;
            secondFileLength = RichTextBoxRight.Text.Length;
            rightFileIsLoaded = true;

            string[] strParts = filename.Split('\\');
            filename = strParts[strParts.Length - 1];
            LabelFileRightName.Text = TrunkString(filename);

            RichTextBoxResult.Text = "";

            //Активация кнопки Сравнить, если оба файла загружены
            if (CanCompareFiles(leftFileIsLoaded, rightFileIsLoaded)){
                CompareButton.Enabled = true;
            }

        }

        private void RichTextBoxLeft_VScroll(object sender, EventArgs e){
            if (!CheckBoxSyncScroll.Checked) return;

            int nPos = GetScrollPos(RichTextBoxLeft.Handle, (int)ScrollBarType.SbVert);
            nPos <<= 16;
            uint wParam = (uint)ScrollBarCommands.SB_THUMBPOSITION | (uint)nPos;
            SendMessage(RichTextBoxRight.Handle, (int)Message.WM_VSCROLL, new IntPtr(wParam), new IntPtr(0));
        }

        private bool CanCompareFiles(bool leftFileIsLoaded, bool rightFileIsLoaded) {
            return leftFileIsLoaded && rightFileIsLoaded;
        }

        //Сравнение файлов
        private void CompareButton_Click(object sender, EventArgs e){
            outlist1.Clear();
            outlist2.Clear();

            firstFileCharDiffsCount = 0;
            secondFileCharDiffsCount = 0;

            diffs = DIFF.diff_main(RichTextBoxLeft.Text, RichTextBoxRight.Text);
            DIFF.diff_cleanupSemanticLossless(diffs);

            //Получить различия в списоки
            chunklist1 = CollectChunks(RichTextBoxLeft);
            chunklist2 = CollectChunks(RichTextBoxRight);

            //Подсветка различий
            PaintChunks(RichTextBoxLeft, chunklist1, ref outlist1);
            PaintChunks(RichTextBoxRight, chunklist2, ref outlist2);

            RichTextBoxLeft.SelectionLength = 0;
            RichTextBoxRight.SelectionLength = 0;

            firstFileDiffsCount = outlist1.Count; //Количество различий в первом файле
            secondFileDiffsCount = outlist2.Count; //Количество различий во втором файле
            diffsCount = firstFileDiffsCount + secondFileDiffsCount; // Общее количество различий

            if (diffsCount > 0){
                    resultStr = $"First file diffs count: {firstFileDiffsCount}\n" +
                                $"Second file diffs count: {secondFileDiffsCount}\n" +
                                $"Total diffs count: {diffsCount}\n\n";

                string firstFileDiffs = "";
                string secondFileDiffs = "";
                string strToWrite;

                foreach (string str in outlist1){
                    strToWrite = str;

                    switch (str) {
                        case "\n": strToWrite = "[LINE BREAK]";
                            break;
                        case "\t":
                            strToWrite = "[TAB]";
                            break;
                        case " ":
                            strToWrite = "[SPACE]";
                            break;
                    }
                    
                    firstFileDiffs += strToWrite.TrimStart('\n') + "\n";
                    firstFileCharDiffsCount += str.Length;
                }
                 
                foreach (string str in outlist2){
                    strToWrite = str;

                    switch (str){
                        case "\n":
                            strToWrite = "[LINE BREAK]";
                            break;
                        case "\t":
                            strToWrite = "[TAB]";
                            break;
                        case " ":
                            strToWrite = "[SPACE]";
                            break;
                    }

                    secondFileDiffs += strToWrite.TrimStart('\n') + "\n";
                    secondFileCharDiffsCount += str.Length;
                }

                charDiffsCount = firstFileCharDiffsCount + secondFileCharDiffsCount;
                //Метрика, которая определяет насколько отличаются файлы
                float diffIndex = (firstFileCharDiffsCount + secondFileCharDiffsCount) / (float)(firstFileLength + secondFileLength);
                float simIndex = 1 - diffIndex;

                resultStr += $"First file by char diffs count: {firstFileCharDiffsCount}\n" +
                             $"Second file by char diffs count: {secondFileCharDiffsCount}\n" +
                             $"Total diffs by char count: {charDiffsCount}\n" +
                             $"Diff index (min -  0, max - 1): {diffIndex}\n" +
                             $"Sim index (min -  0, max - 1): {simIndex}\n\n";

                if (firstFileCharDiffsCount > 0){
                    resultStr += $"First file diffs:\n{firstFileDiffs}\n";
                }else {
                    resultStr += $"No diffs in first file";
                }

                if (secondFileCharDiffsCount > 0){
                    resultStr += $"Second file diffs:\n{secondFileDiffs}";
                }else{
                    resultStr += $"No diffs in second file";
                }

                ButtonSave.Enabled = true;
            }else {
                resultStr = "No diffs";
                ButtonSave.Enabled = false;
            }

            RichTextBoxResult.Text = resultStr;

        }

        //Получить части текста
       private List<Chunk> CollectChunks(RichTextBox RTB){
            RTB.Text = "";
            List<Chunk> chunkList = new List<Chunk>();
            foreach (Diff diff in diffs){
                if (RTB == RichTextBoxRight && diff.operation == Operation.DELETE) continue; 
                if (RTB == RichTextBoxLeft && diff.operation == Operation.INSERT) continue; 
 
                Chunk chunk = new Chunk();
                int length = RTB.TextLength;
                RTB.AppendText(diff.text);
                chunk.startpos = length;
                chunk.length = diff.text.Length;

                if (diff.operation != Operation.EQUAL){
                    chunk.BackColor = (RTB == RichTextBoxLeft) ? colors1[(int)diff.operation]
                                               : colors2[(int)diff.operation];
                }

                chunkList.Add(chunk);
         
            }
            return chunkList;
        }

        //Подсветка различий
       private void PaintChunks(RichTextBox RTB, List<Chunk> chunks, ref List<string> outlist){
            foreach (Chunk chunk in chunks){
                RTB.Select(chunk.startpos, chunk.length);
                RTB.SelectionBackColor = chunk.BackColor;
                
                //Выделение различий
                if (chunk.BackColor == Color.LightGreen || chunk.BackColor == Color.LightSalmon) {
                    outlist.Add(RTB.SelectedText);
                    }
                }
            }


        private void ButtonSave_Click(object sender, EventArgs e){
            if (SaveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            
            //Получаем название файла
            string filename = SaveFileDialog.FileName;
            //Сохраняем файл
            System.IO.File.WriteAllText(filename, resultStr);
        }

        //Обрезка строки
        private string TrunkString(string str, int maxCount = 18){
            return str.Length <= maxCount ? str : str.Substring(0, maxCount - 4) + "...";
        }

        //Удаление лишних пробельных символов
        private string DeleteExcessSpaceCharacters(string str){
               if (String.IsNullOrWhiteSpace(str)){
                return str;
            }

            Regex regex1 = new Regex(@"[ ]+");
            Regex regex2 = new Regex(@"[\r\n]+");
            Regex regex3 = new Regex(@"[\t]+");

           string new_str = regex1.Replace(str, " ");
           new_str = regex2.Replace(new_str, "\n");
           new_str = regex3.Replace(new_str, "\t");

           return new_str;
        }

    }
}
    

