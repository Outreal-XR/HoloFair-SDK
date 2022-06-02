using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicVideosController : BasicLinksController
    {
        VideoModel videoModel;

        public override void SetModel(Model model)
        {
            base.SetModel(model);
            videoModel = (VideoModel)model;
        }

        public void Play()
        {
            videoModel.SetState(VideoModel.State.Playing);
        }

        public void SetFullScreen(bool val)
        {
            videoModel.SetFullScreen(val);
        }

        public void Stop()
        {
            videoModel.SetState(VideoModel.State.Stopped);
        }

    }
}