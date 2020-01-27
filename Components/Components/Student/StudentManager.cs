using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    class StudentManager : IRegistration, IAuthorization
    {
        private int countStudents;

        public StudentManager() 
        {
            countStudents = GlobalData.iniManager.ReadInt("GeneralValues", "countStudents");
        }

        private string GetMD5Hash(string text)
        {
            using (var hashAlg = MD5.Create()) // Создаем экземпляр класса реализующего алгоритм MD5
            {
                byte[] hash = hashAlg.ComputeHash(Encoding.UTF8.GetBytes(text)); // Хешируем байты строки text
                var builder = new StringBuilder(hash.Length * 2); // Создаем экземпляр StringBuilder. Этот класс предназначен для эффективного конструирования строк
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("X2")); // Добавляем к строке очередной байт в виде строки в 16-й системе счисления
                }
                return builder.ToString(); // Возвращаем значение хеша
            }
        }

        private bool EquatePasswords(string password1, string password2)
        {
            if (GetMD5Hash(password1) == password2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Registration(string password,string surname, string name, string group, string pathPhoto) 
        {
            bool addingStudent = true;

            for (int i=1; i <= countStudents; ++i) 
            {
                if (GlobalData.iniManager.ReadString("Student_id" + Convert.ToString(i), "name") == name)
                {
                    addingStudent = false;
                }
            }

            // для рефактиринга - код ниже вставить в условие в цикле, поменяв в условии знак сравнения
            if (addingStudent == true)
            {
                ++countStudents;
                GlobalData.iniManager.WriteString("Student_id" + Convert.ToString(countStudents), "password", GetMD5Hash(password));
                GlobalData.iniManager.WriteString("Student_id" + Convert.ToString(countStudents), "surname", surname);
                GlobalData.iniManager.WriteString("Student_id" + Convert.ToString(countStudents), "name", name);
                GlobalData.iniManager.WriteString("Student_id" + Convert.ToString(countStudents), "group", group);
                GlobalData.iniManager.WriteString("Student_id" + Convert.ToString(countStudents), "path_photo", pathPhoto);
                GlobalData.iniManager.WriteInt("GeneralValues", "countStudents", countStudents);
                MessageBox.Show("Регистрация завершилась успешно!");
            }
            else 
            {
                MessageBox.Show("Ваши данные уже зарегистрированы...");
            }


        }

        public void Authorization(string surname, string password) 
        {
            for (int i = 1; i <= countStudents; ++i)
            {
                if (GlobalData.iniManager.ReadString("Student_id" + Convert.ToString(i), "surname") == surname)
                {
                    //необходим рефакторинг переменных
                    string password1 = GlobalData.iniManager.ReadString("Student_id" + Convert.ToString(i), "password");
                    if (EquatePasswords(password,password1))
                    {
                        MessageBox.Show("Авторизация успешно пройдена!");
                    }
                    else 
                    {
                        MessageBox.Show("Неверный пароль...");
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте правильность введенных данных...");
                }
            }
        }


    }
}
