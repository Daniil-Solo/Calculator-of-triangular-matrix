using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_of_triangular_matrix
{
    class History_message
    {
     // Поля
        private String text;
        private History_message msg_next;
        public static int number = 1;

     // Аксессоры
        public String Text 
        { 
            get { return text; } 
            set { text = value; } 
        }
        public History_message Msg_next 
        {
            get { return msg_next; }
            set { msg_next = value; }
        }
     // Конструктор
        public History_message(String text)
        {
            this.text = text;
            this.msg_next = null;
        }

     // Методы

        // *******Добавление нового сообщения в начало стека******* 
        // Принимает на вход текст нового сообщения
        // Возвращает ссылку на стек с сообщениями
        // Пример вызова: myHistory = myHistory.Add();
        public History_message Add(String text)
        {
            number++;
            History_message newMessage = new History_message(text);
            newMessage.msg_next = this;
            return newMessage;
        }

        // *******Вывод последних k сообщений*******
        // Принимает на вход число сообщений, которы нужно вывести
        // Возвращает строку, состоящую из последних k сообщений
        // Пример вызова: myHistory.Print(4);
        public String Print(int k)
        {
            int n = number;
            History_message p = this;
            String result = "";
            while ((p != null) && (k > 0))
            {
                result = n.ToString() + ". " + p.text + "\r\n" + result;
                p = p.msg_next;
                k--;
                n--;
            }
            return result;
        }

        //*******Очистка истории*******
        // Не принимает на вход параметров
        // Возвращает указатель на конец стека (начало работы с программой)
        // Пример вызова: myHistory = myHistory.Clear_history();
        public History_message Clear_history()
        {
            History_message.number = 1;
            History_message p = this;

            while (p.msg_next != null) 
            {
                p = p.msg_next;
            }
            return p;
        }
        public void Save(String filename)
        {
            StreamWriter f = null;
            try
            {
                f = new StreamWriter(filename);
            }
            catch
            {
                return;
            }
            int n = number;
            String[] stringArr = new string[n];
            History_message p = this;
            while (p != null)
            {
                stringArr[n-1] = (p.Text);
                p = p.msg_next;
                n--;
            }
            for(int i = 0; i < number; i++)
            {
                f.WriteLine((i+1).ToString() + ". " + stringArr[i]);
                stringArr[i] = null;
            }
            stringArr = null;
            f.Close();
        }
    }
}
