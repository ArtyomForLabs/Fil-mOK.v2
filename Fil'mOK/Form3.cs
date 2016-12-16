using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fil_mOK
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
                if (this.tableAdapterManager.UsersTableAdapter.IdbyLog(this.textBox1.Text, this.maskedTextBox1.Text) != null)
                {
                    MessageBox.Show("Добро пожаловать, " + this.textBox1.Text + "!", "Вход успешен!", MessageBoxButtons.OK);
                    Form2 f2 = this.Owner as Form2;
                    f2.Welcome.Text = this.textBox1.Text + " | В сети";
                    f2.Welcome.Location = new Point(0, 0);
                    f2.Welcome.Show();
                    f2.войтиToolStripMenuItem.Visible = false;
                    f2.выйтиToolStripMenuItem.Visible = true;
                    //f2.label1.Enabled = true;
                    //f2.label2.Enabled = true;
                    if (this.bDFilmDataSet.Users.FindById((int)this.tableAdapterManager.UsersTableAdapter.IdbyLog(this.textBox1.Text, this.maskedTextBox1.Text)).Key)
                    {
                        f2.редакторToolStripMenuItem.Visible = true;
                    }
                    else
                    {
                        f2.редакторToolStripMenuItem.Visible = false;
                    }
                    foreach (var cntrl in f2.Controls)
                    {
                        if (cntrl is Panel)
                        {
                            foreach (var label in (cntrl as Panel).Controls)
                            {
                                if (label is Label)
                                {
                                    (label as Label).Enabled = true;
                                }
                            }
                        }
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль!", "Ошибка!", MessageBoxButtons.OK);
                }
           
            
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDFilmDataSet);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.usersTableAdapter.Fill(this.bDFilmDataSet.Users);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button1.Visible = false;
            linkLabel1.Visible = false;
            email.Text = "Email";
            email.AutoSize = true;
            email.Location = new Point(label2.Location.X, label2.Location.Y+39);
            mail.Text = "";
            mail.Size = new System.Drawing.Size(110,20);
            mail.TabIndex = 4;
            mail.Location = new Point(maskedTextBox1.Location.X, maskedTextBox1.Location.Y+39);
            reg.Text = "Зарегистрироваться";
            reg.AutoSize = true;
            reg.TabIndex = 5;
            reg.Location = new Point(mail.Location.X, mail.Location.Y+39);
            this.Controls.Add(email);
            this.Controls.Add(mail);
            this.Controls.Add(reg);
        }

        private void registration(object sender, EventArgs e)
        {
            if ((!textBox1.Text.Equals("")) && (!mail.Text.Equals("")) && (!maskedTextBox1.Text.Equals("")))
            {
                if ((this.tableAdapterManager.UsersTableAdapter.CheckLog(textBox1.Text) == null))
                {
                    usersTableAdapter.Insert(textBox1.Text, maskedTextBox1.Text, mail.Text, false);
                    this.tableAdapterManager.UpdateAll(this.bDFilmDataSet);
                    this.usersTableAdapter.Fill(this.bDFilmDataSet.Users);
                    if (MessageBox.Show("Вы успешно зарегистрированы!", "Добро пожаловать!", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        button1_Click(sender,e);
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь с данным логином уже существует.\nВведите другой логин!", "Ошибка!");
                }
            }
            else
            {
                MessageBox.Show("Вы ввели неверные данные, или некоторые поля остались пустыми", "Ошибка!");
            }
        }

    }
}
