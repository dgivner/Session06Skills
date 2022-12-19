#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

#endregion

namespace Session06Skills
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            string assemblyName = GetAssemblyName();

            //step 1: Create Ribbon Tab (if needed)
            try
            {
                a.CreateRibbonTab("TRB BIM Tools");
            }
            catch (Exception e)
            {
                TaskDialog.Show("Error", e.Message);
                Debug.Print(e.Message);
                return Result.Failed;
            }
            


            //step 2: Create ribbon panel(s)
            RibbonPanel panel1 = a.CreateRibbonPanel("TRB BIM Tools", "Panel 1");
            RibbonPanel panel2 = a.CreateRibbonPanel("TRB BIM Tools", "Panel 2");
            RibbonPanel panel3 = a.CreateRibbonPanel("TRB BIM Tools","Panel 3");

            //step 3: Create button data instances
            PushButtonData pData1 =
                new PushButtonData("button1", "Tool 1", assemblyName, "Session06Skills.Command");
            PushButtonData pData2 =
                new PushButtonData("button2", "Tool 2", assemblyName, "Session06Skills.Command2");
            PushButtonData pData3 =
                new PushButtonData("button3", "Tool 3", assemblyName, "Session06Skills.Command");
            PushButtonData pData4 =
                new PushButtonData("button4", "Tool 4", assemblyName, "Session06Skills.Command2");
            PushButtonData pData5 =
                new PushButtonData("button5", "Tool 5", assemblyName, "Session06Skills.Command");
            PushButtonData pData6 =
                new PushButtonData("button6", "Tool 6", assemblyName, "Session06Skills.Command2");
            PushButtonData pData7 =
                new PushButtonData("button7", "Tool 7", assemblyName, "Session06Skills.Command");
            PushButtonData pData8 =
                new PushButtonData("button8", "Tool 8", assemblyName, "Session06Skills.Command2");
            PushButtonData pData9 =
                new PushButtonData("button9", "Tool 9", assemblyName, "Session06Skills.Command");
            PushButtonData pData10 =
                new PushButtonData("button10", "Tool 10", assemblyName, "Session06Skills.Command2");

            

            PulldownButtonData pullDownData1 = new PulldownButtonData("pulldown1", "More Tools");

            SplitButtonData splitData1 = new SplitButtonData("split1", "Split Button 1");



            //step 4: add images
            pData1.LargeImage = BitMapToImageSource(Session06Skills.Properties.Resources.Blue_32);
            pData1.Image = BitMapToImageSource(Session06Skills.Properties.Resources.Blue_16);
            pData2.LargeImage = BitMapToImageSource(Session06Skills.Properties.Resources.Green_32);
            pData2.Image = BitMapToImageSource(Session06Skills.Properties.Resources.Green_16);
            pData3.LargeImage = BitMapToImageSource(Session06Skills.Properties.Resources.Red_32);
            pData3.Image = BitMapToImageSource(Session06Skills.Properties.Resources.Red_16);
            pData4.LargeImage = BitMapToImageSource(Session06Skills.Properties.Resources.Yellow_32);
            pData4.Image = BitMapToImageSource(Session06Skills.Properties.Resources.Yellow_16);
            pData5.LargeImage = BitMapToImageSource(Session06Skills.Properties.Resources.Blue_32);
            pData5.Image = BitMapToImageSource(Session06Skills.Properties.Resources.Blue_16);
            pData6.LargeImage = BitMapToImageSource(Session06Skills.Properties.Resources.Green_32);
            pData6.Image = BitMapToImageSource(Session06Skills.Properties.Resources.Green_16);
            pData7.LargeImage = BitMapToImageSource(Session06Skills.Properties.Resources.Red_32);
            pData7.Image = BitMapToImageSource(Session06Skills.Properties.Resources.Red_16);
            pData8.LargeImage = BitMapToImageSource(Session06Skills.Properties.Resources.Yellow_32);
            pData8.Image = BitMapToImageSource(Session06Skills.Properties.Resources.Yellow_16);
            pData9.LargeImage = BitMapToImageSource(Session06Skills.Properties.Resources.Red_32);
            pData9.Image = BitMapToImageSource(Session06Skills.Properties.Resources.Red_16);
            pData10.LargeImage = BitMapToImageSource(Session06Skills.Properties.Resources.Yellow_32);
            pData10.Image = BitMapToImageSource(Session06Skills.Properties.Resources.Yellow_16);

            //step 5: add tool tips
            pData1.ToolTip = "Button 1 Tooltip";
            pData2.ToolTip = "Button 2 Tooltip";
            pData3.ToolTip = "Button 3 Tooltip";
            pData4.ToolTip = "Button 4 Tooltip";
            pData5.ToolTip = "Button 5 Tooltip";
            pData6.ToolTip = "Button 6 Tooltip";
            pData7.ToolTip = "Button 7 Tooltip";
            pData8.ToolTip = "Button 8 Tooltip";
            pData9.ToolTip = "Button 9 Tooltip";
            pData10.ToolTip = "Button 10 Tooltip";


            //step 6: Create buttons
            PushButton button1 = panel1.AddItem(pData1) as PushButton;
            PushButton button2 = panel1.AddItem(pData2) as PushButton;

            panel2.AddStackedItems(pData3, pData4, pData5);

            SplitButton splitButton = panel3.AddItem(splitData1) as SplitButton;
            splitButton.AddPushButton(pData6);
            splitButton.AddPushButton(pData7);
            

            PulldownButton pulldownButton = panel2.AddItem(pullDownData1) as PulldownButton;
            pulldownButton.AddPushButton(pData8);
            pulldownButton.AddPushButton(pData9);
            pulldownButton.AddPushButton(pData10);
            


            return Result.Succeeded;
        }

        private BitmapImage BitMapToImageSource(Bitmap image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;
                BitmapImage bmi = new BitmapImage();
                bmi.BeginInit();
                bmi.StreamSource = ms;
                bmi.CacheOption = BitmapCacheOption.OnLoad;
                bmi.EndInit();

                return bmi;
            }
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
        private string GetAssemblyName()
        {
            string assemblyName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            return assemblyName;
        }
    }
}
