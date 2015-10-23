using Prism.Events;
using Scare.Core;
using Scare.Core.Model;
using Scare.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scare.pumpkin.ui.Services
{
    public class MotionActivatedSimpleAnimation:AnimationServiceBase
    {
        private SubscriptionToken _motionEventToken = null;

        public MotionActivatedSimpleAnimation(IEventAggregator events, SoundService sound,TimerService timer):base(events,sound, timer)
        {
            _motionEventToken = _events.GetEvent<Events.PressenceEvent>().Subscribe((args) =>
            {
                this.OnMotionEvent(args);
            }, ThreadOption.UIThread);

        }

        private void OnMotionEvent(PressenceTriggeredArgs args)
        {
            StartAnimation(args.Id);
        }

        public override void StartAnimation(int id)
        {
            if (_animationRunning)
                return;
            _animationRunning = true;
            _actions.Actions.Clear();
            switch(id)
            {
                case 1:
                    LoadAnimation1();
                    break;
                default:
                    LoadAnimationTest();
                    break;
            }
            _timerService.Start();
        }

        public void LoadAnimation1()
        {
            _actions.Actions.Add(Netrual(5));

            _actions.Actions.Add(new ActionSound
            {
                Sequence = 5,
                Channel = 1,
                FileName = "thunder_strike_1.mp3"
            });

            _actions.Actions.Add(Scared(10));

            _actions.Actions.Add(Netrual(16));

            _actions.Actions.Add(Angry(21));
            _actions.Actions.Add(new ActionSound
            {
                Sequence = 20,
                Channel = 2,
                FileName = "dog_howling_at_moon.mp3"
            });
            _actions.Actions.Add(new ActionSound
            {
                Sequence = 25,
                Channel = 2,
                FileName = "howling.wav"
            });

            _actions.Actions.Add(Hide(34));
            _actions.Actions.Add(new ActionTimerStop
            {
                Sequence = 35,
            });

        }

        public void LoadAnimationTest()
        {
            _actions.Actions.Add(Netrual(1));

            _actions.Actions.Add(Scared(7));

            _actions.Actions.Add(Netrual(15));

            _actions.Actions.Add(new ActionTimerStop
            {
                Sequence = 20,
            });

        }

        private ActionFacialCoding Netrual(int sequence)
        {
            ActionFacialCoding code = new ActionFacialCoding();
            code.ActionUnits.Add(new ActionUnit
            {
                FacialActionCodingType = FacialActionCodingType.NeutralFace
            });
            code.Sequence = sequence;
            return code;
        }

        private ActionFacialCoding Scared(int sequence)
        {
            ActionFacialCoding code = new ActionFacialCoding();
            code.ActionUnits.Add(new ActionUnit
            {
                FacialActionCodingType = FacialActionCodingType.JawDrop,
                IntensistyScoring = IntensityScoring.Maximum
            });
            code.ActionUnits.Add(new ActionUnit
            {
                FacialActionCodingType = FacialActionCodingType.BrowLowerer,
                IntensistyScoring = IntensityScoring.Maximum
            });
            code.Sequence = sequence;
            return code;
        }

        private ActionFacialCoding Hide(int sequence)
        {
            ActionFacialCoding code = new ActionFacialCoding();
            code.ActionUnits.Add(new ActionUnit
            {
                FacialActionCodingType = FacialActionCodingType.EntireFaceNotVisible
            });
            code.Sequence = sequence;
            return code;
        }

        private ActionFacialCoding Angry(int sequence)
        {
            ActionFacialCoding code = new ActionFacialCoding();
            code.ActionUnits.Add(new ActionUnit
            {
                FacialActionCodingType = FacialActionCodingType.EyebrowGatherer
            });
            code.ActionUnits.Add(new ActionUnit
            {
                FacialActionCodingType = FacialActionCodingType.InnerEyebrowLowerer
            });
            code.Sequence = sequence;
            return code;

        }
    }
}
