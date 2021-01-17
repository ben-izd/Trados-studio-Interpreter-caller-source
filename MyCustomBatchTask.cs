using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.ProjectAutomation.AutomaticTasks;
using Sdl.ProjectAutomation.Core;
using System.Collections.Generic;
using System.IO;

namespace python_caller
{
    [AutomaticTask("My_Custom_Batch_Task_ID",
                   "My_Custom_Batch_Task_Name",
                   "My_Custom_Batch_Task_Description",

                   GeneratedFileType = AutomaticTaskFileType.BilingualTarget)]

    [AutomaticTaskSupportedFileType(AutomaticTaskFileType.BilingualTarget)]
    [RequiresSettings(typeof(MyCustomBatchTaskSettings), typeof(MyCustomBatchTaskSettingsPage))]

    class MyCustomBatchTask : AbstractFileContentProcessingAutomaticTask
    {
        private MyCustomBatchTaskSettings _settings;

        protected override void OnInitializeTask()
        {
            base.OnInitializeTask();

            _settings = GetSetting<MyCustomBatchTaskSettings>();

        }
        protected override void ConfigureConverter(ProjectFile projectFile, IMultiFileConverter multiFileConverter)
        {


            // projectFile.
            ContentProcessor _processor = new ContentProcessor(_settings);
            // System.IO.File.Copy(projectFile.LocalFilePath.ToString(),);
            // _processor.run_python("0", "0", projectFile.LocalFilePath.ToString());
            // _processor.run_python("0", "0", generate_new_name(projectFile.LocalFilePath.ToString()));
            File.Copy(projectFile.LocalFilePath.ToString(), generate_new_name(projectFile.LocalFilePath.ToString()));
            // _processor.run_python("0", "0", Path.GetFileNameWithoutExtension(projectFile.LocalFilePath.ToString())+"_backup");
            multiFileConverter.AddBilingualProcessor(_processor);

        }
        public override bool OnFileComplete(ProjectFile projectFile, IMultiFileConverter multiFileConverter)
        {
            return true;
        }

        static string generate_new_name(string file_name)
        {
            List<string> a = new List<string>(Path.GetFileName(file_name).Split('.'));
            var temp_ext = "." + string.Join(".", a.GetRange(a.Count - 2, 2));
            a.RemoveRange(a.Count - 2, 2);
            var temp_name_with_no_extension = string.Concat(a);

            var temp_path_name = Path.Combine(Path.GetDirectoryName(file_name) ?? "", temp_name_with_no_extension);
            ;
            string final_name = file_name;
            for (int i = 1; i < 1000; i++)
            {
                final_name = temp_path_name + "_backup_" + i.ToString() + temp_ext;

                if (!File.Exists(final_name))
                {
                    break;
                }

            }

            return final_name;
        }

    }

}
