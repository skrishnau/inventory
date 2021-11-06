using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using ViewModel.Core;

namespace IMS.Forms.Common
{
    public class PopupMessage
    {
        public static void ShowSaveSuccessMessage()
        {
            ShowPopupMessage("Success!", "Saved successfully.", PopupMessageType.SUCCESS);
        }

        public static void ShowMissingInputsMessage()
        {
            ShowPopupMessage("Error!", "Some required fields are missing.", PopupMessageType.ERROR);
        }

        public static void ShowPopupMessage(string title, string message, PopupMessageType messageType)
        {
            PopupNotifier popup = new PopupNotifier();

            // default customization
            var titleColor = Color.Black;
            var contentColor = Color.Black;
            Bitmap image = Properties.Resources.icons8_View_More_24px;

            // customization wrt messageType
            if (messageType == PopupMessageType.ERROR)
            {
                titleColor = Color.Coral;
                //contentColor = Color.Red;
                image = Properties.Resources.icons8_Error_24px;
            }
            else if (messageType == PopupMessageType.INFO)
            {
                titleColor = Color.BlueViolet;
                //contentColor = Color.DarkBlue;
                image = Properties.Resources.icons8_Info_24px;
            }
            else if (messageType == PopupMessageType.SUCCESS)
            {
                titleColor = Color.Green;
               // contentColor = Color.DarkGreen;
                image = Properties.Resources.icons8_Ok_24px;
            }
            popup.Image = image;//Properties.Resources.icons8_Lipstick_48px_3;
            popup.TitleColor = titleColor;
            popup.TitlePadding = new Padding(5, 0, 0, 0);
            popup.ImagePadding = new Padding(5, 0, 0, 0);
            popup.ImageSize = new Size(16, 16);
            popup.ContentColor = contentColor;
            popup.Size = new Size(300, 80);
            popup.ShowGrip = false;
            popup.TitleText = title;
            popup.ContentText = message;
            popup.Popup();// show 
            popup.Click += Popup_Click;
        }

        private static void Popup_Click(object sender, EventArgs e)
        {
            var popup = sender as PopupNotifier;
            MessageBox.Show(popup.ContentText, popup.TitleText);
        }

        internal static void ShowErrorMessage(string msg)
        {
            ShowPopupMessage("Error!", msg, PopupMessageType.ERROR);
        }

        //internal static void ShowInfoMessage(string msg)
        //{
        //    ShowPopupMessage("Info!", msg, PopupMessageType.INFO);
        //}

        internal static void ShowSuccessMessage(string msg)
        {
            ShowPopupMessage("Success!", msg, PopupMessageType.SUCCESS);
        }

        internal static void ShowInfoMessage(string msg)
        {
            ShowPopupMessage("Alert!", msg, PopupMessageType.INFO);
        }
        public static void ShowMessage(ResponseModel<bool> msg)
        {
            if (msg.Success)
                ShowSuccessMessage(msg.Message);
            else
                ShowInfoMessage(msg.Message);
        }
        public static void ShowMessage(bool success, string message)
        {
            if (success)
                ShowSuccessMessage(message);
            else
                ShowInfoMessage(message);
        }
    }

    public enum PopupMessageType
    {
        INFO, // has blue color as a template
        SUCCESS, // has green color as a template
        ERROR, // has red color as a template
        NONE, // has black/white template
        WARNING //has lightpink color 
    }

    public enum PopUpLocation
    {
        TOP, BOTTOM, LEFT, RIGHT, CENTER,
        TOPLEFT, TOPRIGHT,
        BOTTOMLEFT, BOTTOMRIGHT
    }
}
