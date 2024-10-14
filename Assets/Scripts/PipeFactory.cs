using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeFactory
{
    public IPipe CreatePipe(string pipeType)
    {
        switch (pipeType)
        {
            case "Basic":
                return new NormalPipe();
            case "Mobile":
                return new MovingPipe();
            case "DoubleOpening":
                return new DoublePipe();
            default:
                throw new System.Exception("Invalid Pipe Type");
        }
    }
}
