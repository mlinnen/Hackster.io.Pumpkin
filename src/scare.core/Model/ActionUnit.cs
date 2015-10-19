using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scare.Core.Model
{
    public class ActionUnit
    {
        public ActionUnit()
        {
            this.IntensistyScoring = IntensityScoring.None;
            FacialActionCodingType = FacialActionCodingType.NeutralFace;
            Direction = Direction.None;
        }

        public ActionUnit(FacialActionCodingType type)
        {
            this.IntensistyScoring = IntensityScoring.None;
            FacialActionCodingType = type;
            Direction = Direction.None;
        }

        public ActionUnit(FacialActionCodingType type, Direction direction)
        {
            this.IntensistyScoring = IntensityScoring.None;
            FacialActionCodingType = type;
            Direction = direction;
        }

        public FacialActionCodingType FacialActionCodingType { get; set; }
        public IntensityScoring IntensistyScoring { get; set; }
        public Direction Direction { get; set; }
    }
}
