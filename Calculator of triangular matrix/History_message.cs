using System;
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
        
        // Добавление нового сообщения в начало стека 
        // Принимает на вход текст нового сообщения
        // Возвращает ссылку на стек с сообщениями
        public History_message Add(String text)
        {
            History_message newMessage = new History_message(text);
            newMessage.msg_next = this;
            return newMessage;
        }

        // Вывод последних k сообщений
        // Принимает на вход число сообщений, которы нужно вывести
        // Возвращает строку, состоящую из последних k сообщений
        public String Print(int k)
        {
            History_message p = this;
            String result = "";
            while ((p != null) && (k > 0))
            {
                result = p.text + "\r\n" + result;
                p = p.msg_next;
                k--;
            }
            return result;
        }
    }
}
