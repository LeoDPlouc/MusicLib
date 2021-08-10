using AcoustID;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MusicLib.Processing
{
    class AcousticID
    {
        public static string ComputeAcousticId(string path)
        {
            NAudio.Wave.AudioFileReader reader = null;
            ChromaContext context;
            try
            {
                reader = new NAudio.Wave.AudioFileReader(path);

                context = new ChromaContext();
                context.Start(reader.WaveFormat.SampleRate, reader.WaveFormat.Channels);

                int count = 0;
                byte[] buffer = new byte[64];
                do
                {
                    count = reader.Read(buffer, 0, buffer.Length);
                    context.Feed(buffer.Select((byte b) => Convert.ToInt16(b)).ToArray(), count);
                }
                while (count == buffer.Length);
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                reader.Dispose();
            }

            context.Finish();
            return context.GetFingerprint();
        }
    }
}
