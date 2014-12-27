﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace GetTorrentFile
{
    public partial class MainDialog : Form
    {
        private const string magnet_uri_reg_ex = @"magnet:\?xt=urn:btih:(?<hash>.*?)&dn=(?<filename>.*?)&as=(?<download>.*?)";
        private static Dictionary<string, string> Magnet_Uri_Details = new Dictionary<string, string>();
        private static string DownloadLocation = Application.StartupPath + @"\Torrents\";

        public MainDialog()
        {
            InitializeComponent();
        }

        private void Btn_Download_Click(object sender, EventArgs e)
        {
            try
            {
                if (Txt_MagnetLink.Text != null && Txt_MagnetLink.Text.Trim().Length > 0)
                {
                    string magnet_link = Txt_MagnetLink.Text;
                    if (isValidUrl(magnet_link))
                    {
                        magnet_link = Regex.Unescape(magnet_link);
                        Magnet_Uri_Details = GetMagnetUriInfo(magnet_link);
                        if (Magnet_Uri_Details.Keys.Contains("HASH") && Magnet_Uri_Details["HASH"] != null && Magnet_Uri_Details["HASH"].Trim().Length > 0)
                            DownloadTorrentFile();
                        else
                            MessageBox.Show("HASH Not Found.");
                    }
                    else
                    {
                        MessageBox.Show("InValid Magnet Link");
                    }
                }
                else
                    MessageBox.Show("Please Enter Magnet Link");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void DownloadTorrentFile()
        {
            try
            {
                LnkLbl_Open.Visible = false;

                string DownloadUrl = "";
                if (Magnet_Uri_Details.Keys.Contains("DOWNLOAD_URL") && Magnet_Uri_Details["DOWNLOAD_URL"] != null && Magnet_Uri_Details["DOWNLOAD_URL"].Trim().Length > 0)
                    DownloadUrl = Magnet_Uri_Details["DOWNLOAD_URL"];
                else
                    DownloadUrl = "http://torrage.com/torrent/" + Magnet_Uri_Details["HASH"].ToUpper().Trim() + ".torrent";

                if (!Directory.Exists(DownloadLocation))
                    Directory.CreateDirectory(DownloadLocation);

                string FileName = "";
                if (Magnet_Uri_Details.Keys.Contains("FILENAME") && Magnet_Uri_Details["FILENAME"] != null && Magnet_Uri_Details["FILENAME"].Trim().Length > 0)
                    FileName = Magnet_Uri_Details["FILENAME"].Trim();
                else
                    FileName = Magnet_Uri_Details["HASH"].ToUpper().Trim();

                //Zack
                //Date: 12/27/2014
                //To Remove Invalid Characters
                while (FileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                {
                    int _index = FileName.IndexOfAny(Path.GetInvalidFileNameChars());
                    FileName = FileName.Remove(_index, 1);
                }

                string TempTorrentFileName = DownloadLocation + "" + Magnet_Uri_Details["HASH"].ToUpper().Trim() + ".torrent";
                string ActuTorrentFileName = DownloadLocation + "" + FileName + ".torrent";

                if (!File.Exists(TempTorrentFileName))
                {
                    HttpWebRequest DownloadClient = (HttpWebRequest)WebRequest.Create(DownloadUrl);
                    {
                        DownloadClient.Method = "GET";
                        DownloadClient.Credentials = CredentialCache.DefaultCredentials;
                        DownloadClient.Headers.Add("Accept-Encoding", "gzip,deflate");
                        WebResponse resp = DownloadClient.GetResponse();
                        if (resp != null && resp.ContentLength > 0)
                        {
                            Stream memrystrm = resp.GetResponseStream();
                            if (memrystrm != null)
                            {
                                if (resp.Headers["Content-Encoding"].ToLower().Contains("gzip"))
                                    memrystrm = new GZipStream(memrystrm, CompressionMode.Decompress);
                                else if (resp.Headers["Content-Encoding"].ToLower().Contains("deflate"))
                                    memrystrm = new DeflateStream(memrystrm, CompressionMode.Decompress);

                                using (var fileStream = new FileStream(TempTorrentFileName, FileMode.Create, FileAccess.Write))
                                {
                                    memrystrm.CopyTo(fileStream);
                                }
                            }
                        }
                    }
                }
                File.Move(TempTorrentFileName, ActuTorrentFileName);
                LnkLbl_Open.Visible = true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void MainDialog_Load(object sender, EventArgs e)
        {
            try
            {
                string magnet_link = Clipboard.GetText();

                if (magnet_link != null && magnet_link.Trim().Length > 0)
                {
                    if (isValidUrl(magnet_link))
                    {
                        Txt_MagnetLink.Text = Regex.Unescape(magnet_link);
                        Txt_MagnetLink.SelectedText = "";
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool isValidUrl(string MagnetUri)
        {
            //return Regex.IsMatch(MagnetUri, magnet_uri_reg_ex, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
            return true;
        }

        public static Dictionary<string, string> GetMagnetUriInfo(string MagnetUri)
        {
            Dictionary<string, string> RetVal = new Dictionary<string, string>();
            if (MagnetUri != null && MagnetUri.Trim().Length > 0)
            {
                string[] magnet_uri_segments = MagnetUri.Split('&');

                foreach (string IndSegments in magnet_uri_segments)
                {
                    if (IndSegments.ToUpper().Contains("URN:BTIH:"))
                        RetVal.Add("HASH", IndSegments.Substring(IndSegments.ToUpper().Trim().IndexOf("URN:BTIH:") + 9).ToUpper());
                    else if (IndSegments.ToUpper().StartsWith("DN="))
                        RetVal.Add("FILENAME", HttpUtility.UrlDecode(IndSegments.Substring(IndSegments.ToUpper().Trim().IndexOf("DN=") + 3)));
                    else if (IndSegments.ToUpper().StartsWith("AS="))
                        RetVal.Add("DOWNLOAD_URL", IndSegments.Substring(IndSegments.ToUpper().Trim().IndexOf("AS=") + 3));
                }
            }
            return RetVal;
        }

        private void LnkLbl_Open_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(DownloadLocation);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            try
            {
                Txt_MagnetLink.Text = "";
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
