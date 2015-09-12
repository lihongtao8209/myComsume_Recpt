using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Tools
{

    public class FileHelper
    {
        ArrayList dirPathList = new ArrayList();
        private string[] filename_part;
        private string[] repository_path;
        private string[] repository_part = new string[] { "consume\\issue", "consume\\recpt" };
        string[] dirName;
        public void CreateDirs(string dirString)
        {
            string dirPath = "";
            dirName = dirString.Split('\\');
            for (int i = 0; i < dirName.Length; i++)
            {
                dirPath += dirName[i] + "\\";
                if (!Directory.Exists(dirPath))
                {
                    DirectoryInfo r = Directory.CreateDirectory(dirPath);
                    dirPathList.Add(r.FullName);
                }

            }
        }

        public void CreateDirs()
        {
            for (int i = 0; i < repository_path.Length; i++)
            {
                CreateDirs(repository_path[i]);
            }
        }

        public void CreateDir(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                DirectoryInfo r = Directory.CreateDirectory(dirPath);
                dirPathList.Add(r.FullName);
            }
        }

        public string CreateDateTimeDir()
        {
            CreateDir(DateTimeDir);
            return DateTimeDir;
        }

        //设置根路径 如 root 为 c:\ 则合成
        //c:\consume\issue  c:\consume\recpt
        public void SetrepositoryPath(string root)
        {
            int len = repository_part.Length;
            repository_path = new string[len];
            for (int i = 0; i < repository_path.Length; i++)
            {
                repository_path[i] = root + repository_part[i];
            }
        }

        //根据文件名判断目录是 issue目录还是recpt
        public void JudgeDirName(string filename)
        {
            RepositoryPrePath = "";
            filename_part = filename.Split('_');
            for (int i = 0; i < repository_path.Length; i++)
            {
                if (repository_path[i].IndexOf(filename_part[0].ToLower()) != -1)
                {
                    RepositoryPrePath = repository_path[i];
                    return;
                }
            }
        }


        public string RepositoryPrePath
        {
            get;
            set;
        }

        public string DateTimeDir
        {
            get
            {
                int len = filename_part[1].Length - 6;
                return RepositoryPrePath + "\\" + filename_part[1].Substring(0, len);
            }

        }

        public void OutPut()
        {
            for (int i = 0; i < dirPathList.Count; i++)
            {
                Debug.WriteLine(dirPathList[i]);
            }
        }
    }
}
