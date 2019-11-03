﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Net.Wifi;
using System.Collections.Generic;
using Android.Support.V4.App;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace APM
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button scanButton;
        private Button uploadButton;
        private TextView accessPointCount;
        private TextView scanStatus;
        private TextView uploadStatus;

        private GeolocationRequest request;
        private WifiManager wifiManager;

        public IList<ScanResult> scanResultArray;

        private bool scanLoop = false;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            scanButton = FindViewById<Button>(Resource.Id.startScan);
            scanButton.Click += ScanButton_Click;

            uploadButton = FindViewById<Button>(Resource.Id.uploadData);
            uploadButton.Click += UploadButton_Click;

            accessPointCount = FindViewById<TextView>(Resource.Id.accessPointCount);
            accessPointCount.Text = "0";

            scanStatus = FindViewById<TextView>(Resource.Id.scanStatus);
            scanStatus.Text = scanLoop.ToString();

            uploadStatus = FindViewById<TextView>(Resource.Id.uploadStatus);

            wifiManager = (WifiManager)GetSystemService(WifiService);

            //Enable wifi if disabled
            if (!wifiManager.IsWifiEnabled)
            {
                Toast.MakeText(this, "Wifi is disabled!", ToastLength.Long).Show();
                wifiManager.SetWifiEnabled(true);
            }

            //Ask for permission (location)
            ActivityCompat.RequestPermissions(this, new string[] { Android.Manifest.Permission.AccessFineLocation }, 0);
        }

        private async void UploadButton_Click(object sender, System.EventArgs e)
        {
            scanLoop = false;

            ApiHelper api = new ApiHelper();
            //Debug
            System.Diagnostics.Debug.WriteLine("Get data from database");
            AccessPoint.AccessPointKnown = await api.getData();
            System.Diagnostics.Debug.WriteLine(AccessPoint.AccessPointKnown.Count);

            //Debug
            System.Diagnostics.Debug.WriteLine("Main sending method");
            await api.send(AccessPoint.AccessPointContainer);
            uploadStatus.Text = "Upload process finished!";
        }
     
        private async void ScanButton_Click(object sender, System.EventArgs e)
        {
            if(scanLoop)
            {
                scanLoop = false;
                scanStatus.Text = scanLoop.ToString();
            }
            else
            {
                scanLoop = true;
                scanStatus.Text = scanLoop.ToString();
            }

            while(scanLoop)
            {
                //Debug
                System.Diagnostics.Debug.WriteLine("Scan..");

                await startScan();
                accessPointCount.Text = AccessPoint.AccessPointContainer.Count.ToString();
            }
        }
        
        private async Task startScan()
        {
            //get current location
            request = new GeolocationRequest(GeolocationAccuracy.Best);
            var location = await Geolocation.GetLocationAsync(request);

            wifiManager.StartScan();
            scanResultArray = wifiManager.ScanResults;

            bool exist = false;
            for(int i=0; i<scanResultArray.Count; i++)
            {
                //debug
                System.Diagnostics.Debug.WriteLine(scanResultArray[i].Bssid + " " + scanResultArray[i].Level);

                exist = false;
                for(int l=0; l<AccessPoint.AccessPointContainer.Count; l++)
                {
                    if(scanResultArray[i].Bssid == AccessPoint.AccessPointContainer[l].bssid)
                    {
                        exist = true;
                        if(scanResultArray[i].Level > AccessPoint.AccessPointContainer[l].signalLevel)
                        {
                            AccessPoint.AccessPointContainer[l].latitude = location.Latitude;
                            AccessPoint.AccessPointContainer[l].longitude = location.Longitude;
                        }
                    }
                }

                if(!exist)
                {
                    AccessPoint.AccessPointContainer.Add(new AccessPoint(
                        scanResultArray[i].Bssid,
                        scanResultArray[i].Ssid,
                        scanResultArray[i].Frequency,
                        scanResultArray[i].Level,
                        location.Latitude,
                        location.Longitude,
                        AccessPoint.securityType(scanResultArray[i].Capabilities)));
                }
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}