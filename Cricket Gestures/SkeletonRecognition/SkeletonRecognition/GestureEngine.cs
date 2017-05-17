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

                SkeletonPoint handLeft= activeSkeleton.Joints[JointType.HandLeft].Position;
                SkeletonPoint elbowLeft = activeSkeleton.Joints[JointType.ElbowLeft].Position;


                // gesture conditions
                if ((handRight.X <elbowRight.X&&handRight.Y==elbowRight.Y)||( handLeft.X>elbowLeft.X && handLeft.Y == elbowLeft.Y))
                {
                    return "noBall";
                }
                
                else if (handRight.X < elbowRight.X && handRight.Y == elbowRight.Y && handLeft.X > elbowLeft.X && handLeft.Y == elbowLeft.Y)
                {
                    return "wideBall";
                }
                else if (handRight.Y > elbowRight.Y && handRight.X > elbowRight.X)
                {
                   return "out";
                }
                else if (handRight.Y > elbowRight.Y && handRight.X > elbowRight.X&&handLeft.Y>elbowLeft.Y&&handLeft.X<elbowLeft.X)
                {
                    return "six";
                }

                else if (handRight.Y <elbowRight.Y && handRight.X >elbowRight.X&handLeft.Y<elbowLeft.Y&&handLeft.X<elbowLeft.X)
                {
                    return "deadBall";
                
                }
                else if (handRight.X > elbowRight.X && handRight.Y > elbowRight.Y)
                {

                    return "bye";
                }
                else if (handRight.Y > elbowRight.Y && handRight.X > elbowRight.X & handLeft.Y < elbowLeft.Y && handLeft.X < elbowLeft.X)
                {
                    return "cancelBall";

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

       


    }
}
