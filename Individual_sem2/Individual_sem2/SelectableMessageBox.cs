using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual_sem2
{
    /// <summary>
    /// mimics the functionality of a messageBox
    /// change: text is now selectable for copy and pasting
    /// </summary>
    public static class SelectableMessageBox
    {
        public static DialogResult Show(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            Form form = new Form();
            Label label = new Label();
            Button button1 = new Button();
            Button button2 = new Button();

            form.ClientSize = new Size(300, 100);
            form.Text = caption;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;

            label.AutoSize = true;
            label.Text = message;
            label.Location = new Point(10, 10);
            label.MaximumSize = new Size(280, 0);
            label.Font = new Font("Segoe UI", 9);

            button1.Text = "OK";
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(140, 60);

            button2.Text = "Cancel";
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(220, 60);

            form.Controls.Add(label);
            form.Controls.Add(button1);
            form.Controls.Add(button2);

            form.AcceptButton = button1;
            form.CancelButton = button2;

            label.Select();
            label.Focus();

            DialogResult result = form.ShowDialog();

            return result;
        }
    }

}
