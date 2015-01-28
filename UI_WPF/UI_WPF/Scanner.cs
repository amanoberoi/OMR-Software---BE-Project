using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIA;
namespace Scanner
{
    public class Scanner
    {
        
        public ImageFile image;
        public CommonDialog commonDialog;
        public Device scannerDevice;

        public Scanner()
        {
            commonDialog = new CommonDialog();
            scannerDevice = commonDialog.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, false, false);
        }

        public void scan(int DPI)
        {
            image = Process(commonDialog, scannerDevice, DPI);
        }

        public void save(string filename)
        {
            SaveImageToJPEGFile(image, filename);
        }

        private void AdjustScannerSettings(IItem scannnerItem, int scanResolutionDPI, int scanStartLeftPixel,
            int scanStartTopPixel,
            int scanWidthPixels, int scanHeightPixels,
            int brightnessPercents, int contrastPercents)
        {
            const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
            const string WIA_VERTICAL_SCAN_RESOLUTION_DPI = "6148";
            const string WIA_HORIZONTAL_SCAN_START_PIXEL = "6149";
            const string WIA_VERTICAL_SCAN_START_PIXEL = "6150";
            const string WIA_HORIZONTAL_SCAN_SIZE_PIXELS = "6151";
            const string WIA_VERTICAL_SCAN_SIZE_PIXELS = "6152";
            const string WIA_SCAN_BRIGHTNESS_PERCENTS = "6154";
            const string WIA_SCAN_CONTRAST_PERCENTS = "6155";
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_START_PIXEL, scanStartLeftPixel);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_START_PIXEL, scanStartTopPixel);
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_SIZE_PIXELS, scanWidthPixels);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_SIZE_PIXELS, scanHeightPixels);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_BRIGHTNESS_PERCENTS, brightnessPercents);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_CONTRAST_PERCENTS, contrastPercents);
        }

        private void SetWIAProperty(IProperties properties, object propName, object propValue)
        {
            Property prop = properties.get_Item(ref propName);
            prop.set_Value(ref propValue);
        }

        private ImageFile Process (CommonDialog commonDialog, Device scannerDevice, int DPI)
        {
            if (scannerDevice != null)
            {
                Item scannerItem = scannerDevice.Items[1];
                if (DPI == 200)
                    AdjustScannerSettings(scannerItem, DPI, 0, 0, 1700, 2338, 0, 0);
                else if (DPI == 300)
                    AdjustScannerSettings(scannerItem, DPI, 0, 0, 2550, 3507, 0, 0);

                object scanResult = commonDialog.ShowTransfer(scannerItem, WIA.FormatID.wiaFormatJPEG, false);
                if (scanResult != null)
                    image = (ImageFile)scanResult;
            }
            return image;
        }

        private void SaveImageToJPEGFile(ImageFile image, string fileName)
        {

            ImageProcess imgProcess = new ImageProcess();
            object convertFilter = "Convert";
            string convertFilterID = imgProcess.FilterInfos.get_Item(ref convertFilter).FilterID;
            imgProcess.Filters.Add(convertFilterID, 0);
            SetWIAProperty(imgProcess.Filters[imgProcess.Filters.Count].Properties, "FormatID", WIA.FormatID.wiaFormatJPEG);
            image = imgProcess.Apply(image);
            image.SaveFile(fileName);
        }
    }
}
