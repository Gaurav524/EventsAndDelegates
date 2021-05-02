using System;
using System.Threading;

namespace EventsAndDelegates
{
    public class VideoEncoder
    {
        //1- Define a delegate
        //2- Define an event based on that delegate
        //3- Raise the event

        /*Case 1: This is the old way to publish the event by defining delegate explicitly.
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);
        public event VideoEncodedEventHandler VideoEncoded;*/

        /*Case 2: This is the new way (after .Net 3 or something) to publish the event
        without defining delegate explicitly.
        Both works same
        EventHandler
        EventHandler<TEventArgs>*/

        public event EventHandler<VideoEventArgs> VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs() { Video = video });
        }
    }
}
