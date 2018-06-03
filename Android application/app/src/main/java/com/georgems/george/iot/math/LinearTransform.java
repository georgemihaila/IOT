package com.georgems.george.iot.math;

public class LinearTransform {
    public LinearTransform(Interval interval1, Interval interval2){
        this.interval1 = interval1;
        this.interval2 = interval2;
    }

    Interval interval1, interval2;

    public double calculateTransform(double x){
        return ((interval2.x2 - interval2.x1)/(interval1.x2 - interval1.x1) * x + (interval2.x2 - interval1.x2 * (interval2.x2 - interval2.x1) / (interval1.x2 - interval1.x1)));
    }
}
