﻿using Caliburn.Micro;
using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using UIBrowser.Core;

namespace UIBrowser.ViewModels.Partials.Notifications
{
    public class PendingBoxXViewModel : Screen, IShell, IPartialView
    {
        #region Event
        public event UpdatePaletteEventHandler UpdatePalette;
        #endregion

        #region Properties

        public ControlType PaletteControlType => ControlType.WindowX;

        public bool IsPaletteEnabled => false;

        #endregion

        #region Methods
        public async void PendingBox(string cap)
        {
            IPendingHandler handler = null;
            switch (cap)
            {
                case "normal":
                    handler = PendingBoxX.Show("Processing .....", "Normal", Application.Current.MainWindow);
                    break;
                case "info":
                    break;
                case "warning":
                    break;
                case "error":
                    NoticeX.Show("This is a message. This is a message. This is a message. This is a message. This is a message.", "Error", MessageBoxIcon.Error, 3000);
                    break;
                case "question":
                    NoticeX.Show("This is a message. This is a message. This is a message. This is a message. This is a message.", "Question", MessageBoxIcon.Question, 3000);
                    break;
                case "success":
                    NoticeX.Show("This is a message. This is a message. This is a message. This is a message. This is a message.", "Warning", MessageBoxIcon.Success, 3000);
                    break;
                case "image":
                    NoticeX.Show("123", "123", "/UIBrowser;component/Resources/Images/panuon.png", 3000);
                    break;
                case "always":
                    NoticeX.Show("123", "123", "/UIBrowser;component/Resources/Images/panuon.png");
                    break;
            }
            if (handler != null)
            {
                handler.UserCancelling += Handler_UserCancelling;
                await Task.Delay(2000);
                handler.UpdateMessage("Almost complete ...");
                await Task.Delay(4000);
                handler.Close();
            }
        }

        #endregion

        #region Event Handler
        private void Handler_UserCancelling(IPendingHandler sender, Panuon.UI.Silver.Core.PendingBoxCancellingEventArgs e)
        {
            //e.Cancel = true;
        }
        #endregion
    }
}
