using Prism.Events;
using Scare.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scare.Core.Services
{
    public abstract class AnimationServiceBase
    {
        private SoundService _soundService;
        protected TimerService _timerService;
        protected ActionCollection _actions;
        private IEventAggregator _events;
        private SubscriptionToken _timerEventToken = null;
        private SubscriptionToken _animationEventToken = null;
        protected bool _animationRunning;

        public AnimationServiceBase(IEventAggregator events, SoundService sound, TimerService timer)
        {
            _events = events;
            _soundService = sound;
            _timerService = timer;
            _actions = new ActionCollection();
            _timerEventToken = _events.GetEvent<Events.TimerEvent>().Subscribe((args) =>
            {
                this.OnTimer(args);
            }, ThreadOption.UIThread);

            _animationEventToken = _events.GetEvent<Events.AnimationEvent>().Subscribe((args) =>
            {
                this.OnAnimationEvent(args);
            }, ThreadOption.UIThread);
        }

        public virtual void StartAnimation(int id)
        {
        }

        private void OnAnimationEvent(AnimationEventArgs args)
        {
            if (args == null)
                return;
            StartAnimation(args.Id);
        }

        private void OnTimer(TimerEventArgs args)
        {
            var actions = _actions.Actions.Where(q => q.Sequence == args.Sequence);
            foreach (var action in actions)
            {
                switch (action.ActionType)
                {
                    case ActionType.Sound:
                        var sound = ((ActionSound)action);
                        _events.GetEvent<Events.SoundEvent>().Publish(new SoundEventArgs(sound.Channel, sound.FileName));
                        break;
                    case ActionType.FacialCoding:
                        var facial = ((ActionFacialCoding)action);
                        _events.GetEvent<Events.ActionFacialCodingEvent>().Publish(new ActionFacialCodingEventArgs(facial));
                        break;
                    case ActionType.TimerStop:
                        _timerService.Stop();
                        _animationRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
