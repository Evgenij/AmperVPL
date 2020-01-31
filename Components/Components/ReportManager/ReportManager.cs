﻿using System;
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
        private string actions;
        public enum TypeAction { Add, Delete }
        public enum TypeChanges { Plus, Minus, DefautChange }
        public enum TypeComponent
        {
            Ammeter,
            Voltmeter,
            Multimeter,
            Resistor,
            Rheostat,
            VoltageSource,
            Capacitor
        }

        public ReportManager()
        {
            string pathDocument = AppDomain.CurrentDomain.BaseDirectory + "fileExample.docx";
            // создаём документ
            document = DocX.Create(pathDocument);
            document.AddHeaders();
            document.AddFooters();
            document.DifferentFirstPage = true;
            actions = "";
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

        public void AddSection(string sectionName) 
        {
            //var headingTypes = Enum.GetValues(typeof(HeadingType));

            HeadingType heading = HeadingType.Heading1;
            var text = string.Format(sectionName, heading.EnumDescription());
            var paragraph = document.InsertParagraph(text);
            // Set the paragraph's heading type.
            paragraph.Heading(heading).
                Font("Times New Roman").
                FontSize(14).
                Color(Color.Black).
                Bold().
                SpacingLine(22).
                Kerning(14);
            paragraph.IndentationFirstLine = 1.5f;
            paragraph.Alignment = Alignment.left;
            
            document.Save();
        } 

        public void AddToStringAction<T>(T component, TypeAction typeAction)
        {
            if (typeAction == TypeAction.Add)
            {
                if (component is Ammeter)
                {
                    actions = actions + "На схему был добавлен амперметр. ";
                }
                else if (component is Voltmeter)
                {
                    actions = actions + "На схему был добавлен вольтметр. ";
                }
                else if (component is VoltageSource)
                {
                    actions = actions + "На схему был добавлен источник напряжения. ";
                }
                else if (component is Multimeter)
                {
                    actions = actions + "На схему был добавлен мультиметр. ";
                }
                else if (component is Capacitor)
                {
                    actions = actions + "На схему был добавлен конденсатор. ";
                }
                else if (component is Resistor)
                {
                    actions = actions + "На схему был добавлен резистор. ";
                }
                else if (component is Rheostat)
                {
                    actions = actions + "На схему был добавлен реостат. ";
                }
            }
            else if (typeAction == TypeAction.Delete)
            {
                if (component is Ammeter)
                {
                    actions = actions + "Из схемы был удален амперметр. ";
                }
                else if (component is Voltmeter)
                {
                    actions = actions + "Из схемы был удален вольтметр. ";
                }
                else if (component is VoltageSource)
                {
                    actions = actions + "Из схемы был удален источник напряжения. ";
                }
                else if (component is Multimeter)
                {
                    actions = actions + "Из схемы был удален мультиметр. ";
                }
                else if (component is Capacitor)
                {
                    actions = actions + "Из схемы был удален конденсатор. ";
                }
                else if (component is Resistor)
                {
                    actions = actions + "Из схемы был удален резистор. ";
                }
                else if (component is Rheostat)
                {
                    actions = actions + "Из схемы был удален реостат. ";
                }
            }
        }

        public void AddToStringChangesValue(TypeComponent typeComponent, TypeChanges typeChanges, int value) 
        {
            if (typeComponent == TypeComponent.Ammeter)
            {
                actions = actions + "Показания на амперметре были изменены до " + Convert.ToString(value) + " A. ";
            }
            if (typeComponent == TypeComponent.Voltmeter)
            {
                actions = actions + "Показания на вольтметре были изменены до " + Convert.ToString(value) + " В. ";
            }
            if (typeComponent == TypeComponent.Multimeter)
            {
                actions = actions + "Показания на мультиметре были изменены до " + Convert.ToString(value) + " A. ";
            }
            if (typeComponent == TypeComponent.Resistor) 
            {
                if (typeChanges == TypeChanges.Plus)
                {
                    actions = actions + "Сопротивление резистора было увеличено до " + Convert.ToString(value) + " Ом. ";
                }
                else if (typeChanges == TypeChanges.Minus)
                {
                    actions = actions + "Сопротивление резистора было уменьшено до " + Convert.ToString(value) + " Ом. ";
                }
            }
            if (typeComponent == TypeComponent.Rheostat)
            {
                actions = actions + "Сопротивление реостата было изменено до " + Convert.ToString(value) + " Ом. ";
            }
            if (typeComponent == TypeComponent.VoltageSource)
            {
                actions = actions + "Напряжение на источнике напряжения было изменено до " + Convert.ToString(value) + " Ом. ";
            }
        }
        
        //запись измененных значений плоского конденсатора
        public void AddToStringChangesValue(double S, double E, double d) 
        {
            actions = actions + "Площадь пластин плоского конденсатора изменена до " + Convert.ToString(S) + " cм^2, ";
            actions = actions + "также значение относительной диэлектрической проницаемости изменено до " + Convert.ToString(E) + ", ";
            actions = actions + "и расстояние между пластинами изменено до " + Convert.ToString(d) + " мм. ";
        }

        //запись измененных значений цилиндрического конденсатора
        public void AddToStringChangesValue(double R1, double R2, double E, double l)
        {
            actions = actions + "Внутренний и внешний радиусы цилиндрического конденсатора изменены до " + Convert.ToString(R1) + " см и " + Convert.ToString(R2) + " см соответственно, ";
            actions = actions + "также высота конденсатора изменена до " + Convert.ToString(l) + " см, ";
            actions = actions + "и значение относительной диэлектрической проницаемости изменено до " + Convert.ToString(E) + ". ";
        }

        public void AddActionStringToReport() 
        {
            paragraph = document.InsertParagraph(actions).
                Font("Times New Roman").
                FontSize(14).
                Color(Color.Black).
                SpacingLine(15.5).
                Kerning(14);
            paragraph.IndentationFirstLine = 1.5f;
            paragraph.Alignment = Alignment.both;

            document.Save();
            actions = "";
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
