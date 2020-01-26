﻿using System.Windows.Forms;
using Octokit;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.ComponentModel;
using System;

namespace NMSCoordinates
{
    public partial class Form9 : Form
    {
        WebClient webClient;               // Our WebClient that will be doing the downloading for us
        Stopwatch sw = new Stopwatch();
        private string assetUrl;
        private string assetName;

        public Form9(string version)
        {
            InitializeComponent();
            textBox1.Text = version;
            CheckForUpdates();
        }
        private async void CheckForUpdates()
        {
            try
            {
                var client = new GitHubClient(new ProductHeaderValue("NMSCoordinates"));
                var releases = await client.Repository.Release.GetAll("Kevin0M16", "NMSCoordinates");
                var latest = releases[0];
                assetUrl = releases[0].Assets[0].BrowserDownloadUrl;
                assetName = releases[0].Assets[0].Name;
                textBox2.Text = latest.Name;
                //textBox3.Text = assetName;
            }
            catch
            {
                MessageBox.Show("Github Server not available. Could not check version", "Alert");
            }
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                //Call the Process.Start method to open the default browser
                //with a URL:
                System.Diagnostics.Process.Start("http://nmscoordinates.com");
            }
            catch
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }        
    }
}
