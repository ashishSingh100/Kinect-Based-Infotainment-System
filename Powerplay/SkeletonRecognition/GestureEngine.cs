using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletonRecognition
{
    class GestureEngine
    {
        SkeletonPoint position;
        String gestureType;
        int state = 0;
        Boolean condition = false;


        public GestureEngine()
        {
            
        }
        public String Update(Skeleton activeSkeleton)
        {
            bool gestureDetected = false;
            if (activeSkeleton != null)
            {

                //Recognize Gestures
                SkeletonPoint head = activeSkeleton.Joints[JointType.Head].Position;

                SkeletonPoint handRight = activeSkeleton.Joints[JointType.HandRight].Position;
                SkeletonPoint elbowRight = activeSkeleton.Joints[JointType.ElbowRight].Position;

                SkeletonPoint handLeft = activeSkeleton.Joints[JointType.HandLeft].Position;
                SkeletonPoint elbowLeft = activeSkeleton.Joints[JointType.ElbowLeft].Position;


                // gesture conditions
                if(state == 0)
                {
                    condition = (handRight.Y > elbowRight.Y) && (handRight.X < elbowRight.X); //Y^, Xv
                }
                else if (state == 1)
                {
                    condition = (handRight.Y > elbowRight.Y) && (handRight.X > elbowRight.X); //Y^, X^
                }
                else if (state == 2)
                {
                    condition = (handRight.Y < elbowRight.Y) && (handRight.X > elbowRight.X); //Yv, X^
                }
                else if (state == 3)
                {
                    condition = (handRight.Y < elbowRight.Y) && (handRight.X < elbowRight.X); //Yv, Xv
                }
                else if (state == 4)
                {
                    condition = (handRight.Y > elbowRight.Y) && (handRight.X > elbowRight.X); //Y^, X^ 2nd quad
                }



                if (condition == true)
                {
                    gestureDetected = updateState();
                    if (gestureDetected)
                        return "powerplay";
                }

                if(state == 4)
                {
                    return "powerplay";
                }
                
                
                   
                

                //switch (gestureType)
                //{
                //    case "Hi":
                //        if (handRight.Y > elbowRight.Y && handRight.Y > head.Y)
                //            isGestureDetected = true;
                //        break;
                //    case "Namaste":
                //        if (handRight.Y > elbowRight.Y && handLeft.Y > elbowLeft.Y && handRight.Y < head.Y && handLeft.Y < head.Y)
                //            isGestureDetected = true;
                //        break;
                //    default:
                //        isGestureDetected = false;
                //        break;

                //}  
            }
            return "none";
        }

        private Boolean updateState()
        {
            state++;
            if (state == 5)
                state = 1;
            if(state == 4)
            {
                return true;
            }
            return false;
        }



    }
}
