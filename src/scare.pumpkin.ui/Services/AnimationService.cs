using Prism.Events;
using scare.core.Services;
using Scare.Core;
using Scare.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scare.pumpkin.ui.Services
{
    public class AnimationService
    {
        private SoundService _soundService;
        private TimerService _timerService;
        private ActionCollection _actions;
        private IEventAggregator _events;
        private SubscriptionToken _timerEventToken = null;

        public AnimationService(IEventAggregator events, SoundService sound,TimerService timer)
        {
            _events = events;
            _soundService = sound;
            _timerService = timer;
            _actions = new ActionCollection();
            _timerEventToken = _events.GetEvent<Events.TimerEvent>().Subscribe((args) =>
            {
                this.OnTimer(args);
            }, ThreadOption.UIThread);
        }

        private void OnTimer(TimerEventArgs args)
        {
            var actions = _actions.Actions.Where(q => q.Sequence == args.Sequence);
            foreach(var action in actions)
            {
                switch(action.ActionType)
                {
                    case ActionType.Sound:
                        var sound = ((ActionSound)action);
                        _events.GetEvent<Events.SoundEvent>().Publish(new SoundEventArgs(sound.Channel, sound.FileName));
                        break;
                    case ActionType.FacialCoding:
                        var facial = ((ActionFacialCoding)action);
                        _events.GetEvent<Events.ActionFacialCodingEvent>().Publish(new ActionFacialCodingEventArgs(facial));
                        break;
                    default:
                        break;
                }
            }
        }

        public void StartAnimation(int id)
        {
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
            _actions.Actions.Add(Netrual(1));

            _actions.Actions.Add(new ActionSound
            {
                Sequence = 5,
                Channel = 1,
                FileName = "thunder_strike_1.mp3"
            });

            _actions.Actions.Add(Scared(7));

            _actions.Actions.Add(Netrual(15));

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


        }

        public void LoadAnimationTest()
        {
            _actions.Actions.Add(Netrual(1));

            _actions.Actions.Add(Scared(7));

            _actions.Actions.Add(Netrual(15));

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
                FacialActionCodingType = FacialActionCodingType.InnerBrowRaiser,
                IntensistyScoring = IntensityScoring.Maximum
            });
            code.Sequence = sequence;
            return code;
        }

    }
}
