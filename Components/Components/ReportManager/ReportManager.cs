using System;
using System.Drawing;
using Xceed.Words.NET;
using Xceed.Document.NET;
using Word = Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Components
{
    class ReportManager
    {
        private DocX document;
        private Paragraph paragraph;
        private static string[] themesLabs = new string[5] {
            "тема лабы 1","тема лабы 2","тема лабы 3","тема лабы 4","тема лабы 5"
            };
        private static string[] targetLabs = new string[5] {
            "цель лабы 1","цель лабы 2","цель лабы 3","цель лабы 4","цель лабы 5"
            };

        public ReportManager()
        {
            string pathDocument = AppDomain.CurrentDomain.BaseDirectory + "fileExample.docx";
            // создаём документ
            document = DocX.Create(pathDocument);
            document.AddHeaders();
            document.AddFooters();
            document.DifferentFirstPage = true; 
        }

        /*рефакторинг - добавить группу студента как параметр 
        и в этом конструкторе вызывать методы создания колонтитулов */
        public ReportManager(string surname, string name, int numLab)
        {
            string pathDocument = AppDomain.CurrentDomain.BaseDirectory + surname + "_" + name +"_Lab"+Convert.ToString(numLab)+".docx";
            // создаём документ
            document = DocX.Create(pathDocument);
            document.AddHeaders();
            document.AddFooters();
            document.DifferentFirstPage = true;
            document.DifferentOddAndEvenPages = true;

            //paragraph = document.InsertParagraph();
        }

        public string GetLabTheme(int numLab)
        {
            if (numLab >= 5)
            {
                return "none";
            }
            else
            {
                return themesLabs[numLab - 1];
            }
        }

        public string GetLabTarget(int numLab)
        {
            if (numLab >= 5)
            {
                return "none";
            }
            else
            {
                return targetLabs[numLab - 1];
            }
        }

        public void AddHeader(string surname, string name, string group)
        {
            document.Headers.First.InsertParagraph(surname + " " + name + " " + group).
                Font("Times New Roman").
                FontSize(12);
            document.Headers.Even.InsertParagraph(surname + " " + name + " " + group).
                Font("Times New Roman").
                FontSize(12);
            document.Headers.Odd.InsertParagraph(surname + " " + name + " " + group).
                Font("Times New Roman").
                FontSize(12);

            document.Save();
        }

        public void AddFooter()
        {
            document.Footers.First.InsertParagraph("стр ").
                Font("Times New Roman").
                FontSize(12).
                AppendPageNumber(PageNumberFormat.normal).Alignment = Alignment.right;

            document.Footers.Even.InsertParagraph("стр ").
                Font("Times New Roman").
                FontSize(12).
                AppendPageNumber(PageNumberFormat.normal).Alignment = Alignment.right;

            document.Footers.Odd.InsertParagraph("стр ").
                Font("Times New Roman").
                FontSize(12).
                AppendPageNumber(PageNumberFormat.normal).Alignment = Alignment.right;

            document.Save();
        }

        public void AddReportHead(string numLab, string theme, string target)
        {
            // вставляем параграф и передаём текст
            document.InsertParagraph("Лабораторная работа №" + numLab).
                Font("Times New Roman").
                FontSize(14).
                Color(Color.Black).
                SpacingLine(15.5).
                Kerning(14).
                Alignment = Alignment.center;

            document.InsertParagraph("Тема: " + theme).
                Font("Times New Roman").
                FontSize(14).
                Color(Color.Black).
                SpacingLine(15.5).
                Kerning(14).
                Alignment = Alignment.center;

            document.InsertParagraph("Цель: " + target).
                Font("Times New Roman").
                FontSize(14).
                Color(Color.Black).
                SpacingLine(15.5).
                Kerning(14).
                Alignment = Alignment.center;

            // вставляем параграф и добавляем текст
            document.InsertParagraph("Ход работы:").
                SpacingBefore(20).
                Font("Times New Roman").
                FontSize(14).
                Color(Color.Black).
                SpacingLine(15.5).
                Kerning(14).
                Alignment = Alignment.center;

            document.Save();
        }

        public void AddedComponents(string action) 
        {
            paragraph = document.InsertParagraph(action).
                Font("Times New Roman").
                FontSize(14).
                Color(Color.Black).
                SpacingLine(15.5).
                Kerning(14);
            paragraph.IndentationFirstLine = 1.5f;
            paragraph.Alignment = Alignment.both;

            document.Save();
        }

        public void AddChangingValue<T>(GlobalData.TypeComponent typeComponent, T value) 
        {
            
            if (typeComponent == GlobalData.TypeComponent.Ammeter) 
            {
                paragraph = document.
                    InsertParagraph("Показания амперметра равны " + value + "ампер. ").
                    Font("Times New Roman").
                    FontSize(14).
                    Color(Color.Black).
                    SpacingLine(15.5).
                    Kerning(14);
                paragraph = document.
                    InsertParagraph("lfkmtbkfngkjfxn");
            }

            document.Save();
        }

        public void AddСonclusion(string resultString) 
        {
            document.InsertParagraph("Вывод:").
                SpacingBefore(20).
                Font("Times New Roman").
                FontSize(14).
                Color(Color.Black).
                SpacingLine(15.5).
                Kerning(14).
                Alignment = Alignment.center;

            var p2 = document.
                InsertParagraph(resultString).
                Font("Times New Roman").
                FontSize(14).
                Color(Color.Black).
                SpacingLine(15.5).
                Kerning(14);
            p2.IndentationFirstLine = 1.5f;
            p2.Alignment = Alignment.both;

            document.Save();
        }

    }
}
