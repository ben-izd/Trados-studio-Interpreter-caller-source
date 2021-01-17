using Sdl.FileTypeSupport.Framework.BilingualApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;


namespace python_caller
{
    public class ContentProcessor : AbstractBilingualContentProcessor
    {
        private MyCustomBatchTaskSettings Settings;

        public bool debug;

        public ContentProcessor(MyCustomBatchTaskSettings ArgSettings)
        {
            Settings = ArgSettings;

            if (Settings.SettingsPythonFileForDebug.Trim() != "")
            {
                this.debug = true;
            }
        }


        public override void ProcessParagraphUnit(IParagraphUnit paragraphUnit)
        {


            base.ProcessParagraphUnit(paragraphUnit);
            if (paragraphUnit.IsStructure)
            {
                return;
            }



            Dictionary<Sdl.Core.Globalization.ConfirmationLevel, string> statuses_text = new Dictionary<Sdl.Core.Globalization.ConfirmationLevel, string> {
            {Sdl.Core.Globalization.ConfirmationLevel.Unspecified ,"Not Translated" },
            {Sdl.Core.Globalization.ConfirmationLevel.Draft ,"Draft"},
            {Sdl.Core.Globalization.ConfirmationLevel.Translated ,"Translated"},
            {Sdl.Core.Globalization.ConfirmationLevel.RejectedTranslation ,"Translation Rejected"},
            {Sdl.Core.Globalization.ConfirmationLevel.ApprovedTranslation ,"Translation Approved"},
            {Sdl.Core.Globalization.ConfirmationLevel.RejectedSignOff ,"Sign-off Rejected"},
            {Sdl.Core.Globalization.ConfirmationLevel.ApprovedSignOff ,"Signed Off"}
            };

            List<Sdl.Core.Globalization.ConfirmationLevel> statuses = statuses_text.Keys.ToList();

            foreach (var segmentPair in paragraphUnit.SegmentPairs)

            {
                if (segmentPair.Target == null)
                {
                    continue;
                }



                string start_time = debug ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff") : "";

                var segment_number = int.Parse(segmentPair.Properties.Id.ToString());
                string old_target = segmentPair.Target.ToString();
                string old_source = segmentPair.Source.ToString();

                bool skip_for_range = segment_number < Settings.SettingsLimitRangeStart || (segment_number > Settings.SettingsLimitRangeEnd && Settings.SettingsLimitRangeEnd != 0);

                string segment_status = statuses_text[segmentPair.Properties.ConfirmationLevel];

                string translation_origin = "";

                foreach (var b in segmentPair.Properties.TranslationOrigin?.MetaData ?? new Dictionary<string, string>())
                {
                    string temp_key = b.Key.ToString().Trim('"', '\'');
                    if (temp_key == "SegmentIdentityHash" || temp_key == "SDL:OriginalTranslationHash" || temp_key == "SDL:ProjectTranslationHash") continue;
                    // translation_origin += " \"" + temp_key + "\" \"" + b.Value.ToString().Trim('"', '\'').Replace(",", " ") + "\"";
                    translation_origin += $"\"{temp_key}\" \"{b.Value.ToString().Trim('"', '\'').Replace(",", " ")}\" ";
                }


                bool skip_for_status;

                switch (Settings.SettingsFilterStatusIndex)
                {
                    case 0:
                        skip_for_status = false;
                        break;
                    case int n when (1 <= n && n <= 7):
                        skip_for_status = !segmentPair.Properties.ConfirmationLevel.Equals(statuses[Settings.SettingsFilterStatusIndex - 1]);
                        break;
                    default:
                        skip_for_status = true;
                        break;
                }


                bool skip_for_apply_mode;

                switch (Settings.SettingsApplyModeIndex)
                {
                    case 0:
                        skip_for_apply_mode = false;
                        break;
                    case 1:
                        skip_for_apply_mode = old_target.Trim() == "";
                        break;
                    case 2:
                        skip_for_apply_mode = segmentPair.Target.Count != 1 || old_target.Trim() == "";
                        break;
                    case 3:
                        skip_for_apply_mode = segmentPair.Source.Count != 1 || old_source.Trim() == "";
                        break;
                    case 4:
                        skip_for_apply_mode = old_target.Trim() != "";
                        break;
                    default:
                        skip_for_apply_mode = true;
                        break;

                }



                if (skip_for_range || skip_for_apply_mode || skip_for_status)
                {
                    if (debug && !skip_for_range)
                    {
                        debug_with_python(
                            segment_number,
                            segment_status,
                            segment_status,
                            old_source,
                            old_source,
                            old_target,
                            old_target,
                            segmentPair.Target.Count,
                            start_time,
                            skip_for_apply_mode ? 1 : 0,
                            skip_for_range ? 1 : 0,
                            skip_for_status ? 1 : 0,
                            -1,
                            translation_origin);
                    }
                    continue;
                }




                string result = run_python(segmentPair.Properties.Id.ToString(), segment_status, old_source, old_target, translation_origin);

                bool skip_for_skipping_keyword = Settings.SettingsUseSkippingKeyword ? result == Settings.SettingsSkippingKeyword : false;

                if (!skip_for_skipping_keyword)
                {
                    if (Settings.SettingsUseReturnText)
                    {

                        switch (Settings.SettingsReturnTextUsageIndex)
                        {
                            case 0:
                                if (result.Trim() != old_target.Trim())
                                {
                                    segmentPair.Target.Clear();

                                    segmentPair.Target.Insert(segmentPair.Target.Count, ItemFactory.CreateText(PropertiesFactory.CreateTextProperties(result)));
                                }
                                break;
                            case 2:
                                if (result.Trim() != old_source.Trim())
                                {
                                    segmentPair.Source.Clear();

                                    segmentPair.Source.Insert(segmentPair.Source.Count, ItemFactory.CreateText(PropertiesFactory.CreateTextProperties(result)));
                                }
                                break;
                            case 1:
                                try
                                {
                                    // check whethere returned value is a number
                                    int temp_index = int.Parse(result.Trim());
                                    if (temp_index >= 0 && temp_index <= 6)
                                    {
                                        segmentPair.Properties.ConfirmationLevel = statuses[temp_index];
                                    }

                                }
                                catch (FormatException)
                                {
                                    int temp_status_index;
                                    switch (result.ToLower().Trim())
                                    {
                                        case "not translated":
                                            temp_status_index = 0;
                                            break;

                                        case "draft":
                                            temp_status_index = 1;
                                            break;

                                        case "translated":
                                            temp_status_index = 2;
                                            break;

                                        case "translation rejected":
                                            temp_status_index = 3;
                                            break;

                                        case "translation approved":
                                            temp_status_index = 4;
                                            break;

                                        case "signed off":
                                            temp_status_index = 6;
                                            break;

                                        case string n when (n == "sign-off rejected" || n == "sign off rejected"):
                                            temp_status_index = 5;
                                            break;


                                        default:
                                            temp_status_index = -1;
                                            break;
                                    }
                                    if (temp_status_index != -1)
                                    {
                                        segmentPair.Properties.ConfirmationLevel = statuses[temp_status_index];
                                    }
                                }
                                break;

                        }


                    }
                    if (Settings.SettingsChangeStatus && ((Settings.SettingsUseReturnText && Settings.SettingsReturnTextUsageIndex != 1) || !Settings.SettingsUseReturnText))
                    {
                        segmentPair.Properties.ConfirmationLevel = statuses[Settings.SettingsStatusIndex];
                    }
                }

                if (debug)
                {
                    debug_with_python(
                        segment_number,
                        segment_status,
                        statuses_text[segmentPair.Properties.ConfirmationLevel],
                        old_source,
                        segmentPair.Source.ToString(),
                        old_target,
                        segmentPair.Target.ToString(),
                        segmentPair.Target.Count(),
                        start_time,
                        0,
                        0,
                        0,
                        skip_for_skipping_keyword ? 1 : 0,
                        translation_origin,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff"));
                }


            }


        }
        public string run_python(string SegmentNumber, string SegmentStatus, string SourceText, string TargetText, string TranslationOrigin)
        {

            SourceText = SourceText.Replace("\"", "\\\"");
            TargetText = TargetText.Replace("\"", "\\\"");

            Process start = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    CreateNoWindow = true,
                    FileName = Settings.SettingsPythonPath,
                    Arguments = $"\"{Settings.SettingsPythonFile}\" \"{SegmentNumber}\" \"{SourceText}\" \"{TargetText}\" \"{SegmentStatus}\" {TranslationOrigin}",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    StandardOutputEncoding = Encoding.UTF8,
                    WorkingDirectory = Path.GetDirectoryName(Settings.SettingsPythonFile)
                }
            };

            start.Start();


            // string output = start.StandardOutput.ReadToEnd();
            string output = "";
            while (!start.StandardOutput.EndOfStream)
            {
                output += start.StandardOutput.ReadLine();
            }
            start.Close();
            return output;
        }



        public void debug_with_python(
                                        int segment_id,
                                        string OldSegmentStatus,
                                        string NewSegmentStatus,
                                        string old_source_text,
                                        string new_source_text,
                                        string old_target_text,
                                        string new_target_text,
                                        int old_target_count,
                                        string send_time,
                                        int skip_for_selection_mode,
                                        int skip_for_range,
                                        int skip_for_status,
                                        int skip_for_skipping_keyword,
                                        string TranslationOrigin,
                                        string recieved_time = "0000-00-00 00:00:00.00")
        {

            Process start = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    CreateNoWindow = true,
                    FileName = Settings.SettingsPythonPath,
                    Arguments = $"\"{Settings.SettingsPythonFileForDebug}\" \"{segment_id}\" \"{OldSegmentStatus}\" \"{NewSegmentStatus}\" \"{old_source_text}\" \"{new_source_text}\" \"{old_target_text}\" \"{new_target_text}\" \"{old_target_count}\" \"{send_time}\" \"{recieved_time}\" \"{skip_for_selection_mode}\" \"{skip_for_range}\" \"{skip_for_status}\" \"{skip_for_skipping_keyword}\" {TranslationOrigin}",
                    UseShellExecute = false,
                    WorkingDirectory = Path.GetDirectoryName(Settings.SettingsPythonFileForDebug)
                }
            };

            start.Start();
            start.Close();

        }


    }
}
