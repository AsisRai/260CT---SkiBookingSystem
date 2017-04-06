using System;

namespace Group_AJR___SBC_Booking_System
{
    interface InstructorType
    {
        bool type(bool i);
    }

    class Yes : InstructorType
    {
        public bool type(bool i)
        {
            return true;
        }
    }

    class No : InstructorType
    {
        public bool type(bool i)
        {
            return false;
        }
    }

    class Factory
    {
        static public InstructorType getType(bool i)
        {
            InstructorType type = null;

            switch (i)
            {
                case false:
                    type = new Yes();
                    break;
                case true:
                    type = new No();
                    break;
            }
            return type;
        }
    }
}
