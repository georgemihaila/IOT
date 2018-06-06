package com.georgems.george.iot;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ScrollView;
import android.widget.SeekBar;
import android.widget.TextView;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.georgems.george.iot.api.API;
import com.georgems.george.iot.math.Interval;
import com.georgems.george.iot.math.LinearTransformation;

import java.util.Random;

public class MainActivity extends AppCompatActivity {
    static {
        System.loadLibrary("native-lib");
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        //Setup reference to main elements
        LinearLayout mainLinearLayout = findViewById(R.id.mainLinearLayout);
        ScrollView mainScrollView = (ScrollView)findViewById(R.id.mainScrollView);
        //Setup TextViews and SeekBars
        for (int i = 0; i < API.RGBWWControl.LEDCount; i++){

            ledName_TextView[i] = new TextView(this);
            ledName_TextView[i].setText(API.RGBWWControl.ledName[i] + " - " + i * API.RGBWWControl.PWM_Max / API.RGBWWControl.LEDCount);
            mainLinearLayout.addView(ledName_TextView[i]);
            final ViewGroup.MarginLayoutParams marginLayoutParams = (ViewGroup.MarginLayoutParams)ledName_TextView[i].getLayoutParams();
            marginLayoutParams.leftMargin = 20;


            ledPWMValue_SeekBar[i] = new SeekBar(this);
            ledPWMValue_SeekBar[i].setMax(API.RGBWWControl.PWM_Max);
            ledPWMValue_SeekBar[i].setTag(i);
            ledPWMValue_SeekBar[i].setProgress(i * API.RGBWWControl.PWM_Max / API.RGBWWControl.LEDCount);
            ledPWMValue_SeekBar[i].setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {

                @Override
                public void onStopTrackingTouch(SeekBar seekBar) {
                    String url = API.RGBWWControl.createPWMRequestString(seekBar);
                    setInfo(url);
                    GETRequest_Blank(url);
                }

                @Override
                public void onStartTrackingTouch(SeekBar seekBar) {

                }

                @Override
                public void onProgressChanged(SeekBar seekBar, int progress,boolean fromUser) {
                    int index = (int)seekBar.getTag();
                    ledName_TextView[index].setText(API.RGBWWControl.ledName[index] + " - " + progress);
                    if (!ignoreProgressChange)
                        ledBrightness_SeekBar.setProgress(getLEDBrightness());
                }
            });
            mainLinearLayout.addView(ledPWMValue_SeekBar[i]);
        }

        randomColor_Button = new Button(this);
        randomColor_Button.setText("Set random color");
        randomColor_Button.setOnClickListener(new Button.OnClickListener() {
            @Override
            public void onClick(View view) {
                Random random = new Random();
                for (int i = 0; i < API.RGBWWControl.LEDCount; i++){
                    ledPWMValue_SeekBar[i].setProgress(random.nextInt(API.RGBWWControl.PWM_Max + 1));
                }
                String url = API.RGBWWControl.createPWMRequestString(new API.RGBWWControl.led[]{API.RGBWWControl.led.cw, API.RGBWWControl.led.r,API.RGBWWControl.led.g,API.RGBWWControl.led.b,API.RGBWWControl.led.ww}, new int[] {ledPWMValue_SeekBar[0].getProgress(), ledPWMValue_SeekBar[1].getProgress(), ledPWMValue_SeekBar[2].getProgress(), ledPWMValue_SeekBar[3].getProgress(), ledPWMValue_SeekBar[4].getProgress()});
                setInfo(url);
                GETRequest_Blank(url);
            }
        });
        mainLinearLayout.addView(randomColor_Button);
        final ViewGroup.MarginLayoutParams marginLayoutParams0 = (ViewGroup.MarginLayoutParams)randomColor_Button.getLayoutParams();
        marginLayoutParams0.leftMargin = 20;
        marginLayoutParams0.width = 300;

        allOn_Button = new Button(this);
        allOn_Button.setText("MAX");
        allOn_Button.setOnClickListener(new Button.OnClickListener(){
            @Override
            public void onClick(View view) {
                for (int i = 0; i < API.RGBWWControl.LEDCount; i++){
                    ledPWMValue_SeekBar[i].setProgress(API.RGBWWControl.PWM_Max);
                    String url = API.RGBWWControl.createSimpleRequestString(API.RGBWWControl.simpleCommand.turnAllLEDsOn);
                    setInfo(url);
                    GETRequest_Blank(url);
                }
            }
        });
        mainLinearLayout.addView(allOn_Button);
        final ViewGroup.MarginLayoutParams marginLayoutParams3 = (ViewGroup.MarginLayoutParams)allOn_Button.getLayoutParams();
        marginLayoutParams3.width = 100;
        marginLayoutParams3.leftMargin = 20;

        allOff_Button = new Button(this);
        allOff_Button.setText("MIN");
        allOff_Button.setOnClickListener(new Button.OnClickListener(){
            @Override
            public void onClick(View view) {
                for (int i = 0; i < API.RGBWWControl.LEDCount; i++){
                    ledPWMValue_SeekBar[i].setProgress(API.RGBWWControl.PWM_Min);
                    String url = API.RGBWWControl.createSimpleRequestString(API.RGBWWControl.simpleCommand.turnAllLEDsOff);
                    setInfo(url);
                    GETRequest_Blank(url);
                }
            }
        });
        mainLinearLayout.addView(allOff_Button);
        final ViewGroup.MarginLayoutParams marginLayoutParams2 = (ViewGroup.MarginLayoutParams)allOff_Button.getLayoutParams();
        marginLayoutParams2.width = 100;
        marginLayoutParams2.leftMargin = 20;

        ledBrightness_TextView = new TextView(this);
        ledBrightness_TextView.setText("Brightness: " + getLEDBrightness() + "%");
        mainLinearLayout.addView(ledBrightness_TextView);
        final ViewGroup.MarginLayoutParams marginLayoutParams1  = (ViewGroup.MarginLayoutParams)ledBrightness_TextView.getLayoutParams();
        marginLayoutParams1.leftMargin = 20;

        ledBrightness_SeekBar = new SeekBar(this);
        ledBrightness_SeekBar.setMax(100);
        ledBrightness_SeekBar.setProgress(getLEDBrightness());
        ledBrightness_SeekBar.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {
                ignoreProgressChange = false;
                String url = API.RGBWWControl.createPWMRequestString(new API.RGBWWControl.led[]{API.RGBWWControl.led.cw, API.RGBWWControl.led.r,API.RGBWWControl.led.g,API.RGBWWControl.led.b,API.RGBWWControl.led.ww}, new int[] {1023 - ledPWMValue_SeekBar[0].getProgress(), 1023 - ledPWMValue_SeekBar[1].getProgress(), 1023 - ledPWMValue_SeekBar[2].getProgress(), 1023 - ledPWMValue_SeekBar[3].getProgress(), 1023 - ledPWMValue_SeekBar[4].getProgress()});
                setInfo(url);
                GETRequest_Blank(url);
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {
                transformOrigin = seekBar.getProgress();
                ignoreProgressChange = true;
                for (int i = 0; i < API.RGBWWControl.LEDCount; i++) {
                    positiveLinearTransformations[i] = new LinearTransformation(new Interval(transformOrigin, seekBar.getMax()), new Interval(ledPWMValue_SeekBar[i].getProgress(), ledPWMValue_SeekBar[i].getMax()));
                    negativeLinearTransformations[i] = new LinearTransformation(new Interval(0, transformOrigin), new Interval(API.RGBWWControl.PWM_Min, ledPWMValue_SeekBar[i].getProgress()));
                }
            }

            @Override
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                if (fromUser){
                    if (transformOrigin < seekBar.getProgress()){
                        for (int i = 0; i < API.RGBWWControl.LEDCount; i++){
                            if (progress == seekBar.getMax()){
                                //Handle possible int cast error.
                                ledPWMValue_SeekBar[i].setProgress(ledPWMValue_SeekBar[i].getMax());
                            }
                            else{
                                ledPWMValue_SeekBar[i].setProgress((int) positiveLinearTransformations[i].calculateTransform(progress));
                            }
                        }
                    }
                    else {
                        for (int i = 0; i < API.RGBWWControl.LEDCount; i++){
                            ledPWMValue_SeekBar[i].setProgress((int) negativeLinearTransformations[i].calculateTransform(progress));
                        }
                    }
                }
                ledBrightness_TextView.setText("Brightness: " + getLEDBrightness() + "%");
            }
        });
        mainLinearLayout.addView(ledBrightness_SeekBar);

        vumeter_Button = new Button(this);
        vumeter_Button.setText("Vumeter");
        vumeter_Button.setOnClickListener(new Button.OnClickListener(){
            @Override
            public void onClick(View view) {
                for (int i = 0; i < API.RGBWWControl.LEDCount; i++){
                    String url = API.RGBWWControl.createSimpleRequestString(API.RGBWWControl.simpleCommand.switchVumeter);
                    setInfo(url);
                    GETRequest_Blank(url);
                }
            }
        });
        mainLinearLayout.addView(vumeter_Button);
        final ViewGroup.MarginLayoutParams marginLayoutParams5 = (ViewGroup.MarginLayoutParams)vumeter_Button.getLayoutParams();
        marginLayoutParams5.width = 200;
        marginLayoutParams5.leftMargin = 20;

        for (int i = 0; i < API.RGBWWControl.LEDCount; i++){
            vufilter_TextView[i] = new TextView(this);
            vufilter_TextView[i].setText(i * 10);
            mainLinearLayout.addView(vufilter_TextView[i]);
            final ViewGroup.MarginLayoutParams marginLayoutParams = (ViewGroup.MarginLayoutParams)vufilter_TextView[i].getLayoutParams();
            marginLayoutParams.leftMargin = 20;

            vufilter_SeekBar[i] = new SeekBar(this);
            vufilter_SeekBar[i].setMax(100);
            vufilter_SeekBar[i].setProgress(i * 10);
            vufilter_SeekBar[i].setTag(i);
            vufilter_SeekBar[i].setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {

                @Override
                public void onStopTrackingTouch(SeekBar seekBar) {
                    ignoreProgressChange = false;
                    String url = API.RGBWWControl.createPWMRequestString(new API.RGBWWControl.led[]{API.RGBWWControl.led.cw, API.RGBWWControl.led.r,API.RGBWWControl.led.g,API.RGBWWControl.led.b,API.RGBWWControl.led.ww}, new int[] {1023 - ledPWMValue_SeekBar[0].getProgress(), 1023 - ledPWMValue_SeekBar[1].getProgress(), 1023 - ledPWMValue_SeekBar[2].getProgress(), 1023 - ledPWMValue_SeekBar[3].getProgress(), 1023 - ledPWMValue_SeekBar[4].getProgress()});
                    setInfo(url);
                    GETRequest_Blank(url);
                }

                @Override
                public void onStartTrackingTouch(SeekBar seekBar) {

                }

                @Override
                public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                    int index = (int)seekBar.getTag();
                    vufilter_TextView[index].setText(progress);
                }
            });
            mainLinearLayout.addView(vufilter_SeekBar[i]);
            final ViewGroup.MarginLayoutParams marginLayoutParams6 = (ViewGroup.MarginLayoutParams)vufilter_SeekBar[i].getLayoutParams();
            marginLayoutParams6.leftMargin = 20;
        }
    }

    //region Properties

    //UI elements
    TextView[] ledName_TextView = new TextView[API.RGBWWControl.LEDCount];
    SeekBar[] ledPWMValue_SeekBar = new SeekBar[API.RGBWWControl.LEDCount];
    TextView ledBrightness_TextView;
    SeekBar ledBrightness_SeekBar;
    Button randomColor_Button;
    Button allOff_Button;
    Button allOn_Button;
    Button vumeter_Button;
    SeekBar[] vufilter_SeekBar = new SeekBar[API.RGBWWControl.LEDCount];
    TextView[] vufilter_TextView = new TextView[API.RGBWWControl.LEDCount];

    //Transforms and properties for handling the brightness seek bar changes.
    boolean ignoreProgressChange = false;
    int transformOrigin = 0;
    LinearTransformation[] positiveLinearTransformations = new LinearTransformation[API.RGBWWControl.LEDCount];
    LinearTransformation[] negativeLinearTransformations = new LinearTransformation[API.RGBWWControl.LEDCount];


    //region Methods

    private void GETRequest_Blank(String url){
        RequestQueue queue = Volley.newRequestQueue(this);
        StringRequest stringRequest = new StringRequest(Request.Method.GET, url,
                new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        setInfo(response);
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                setInfo(error.toString());
            }
        });
        queue.add(stringRequest);
    }

    private void setInfo(String s){
        ((TextView)findViewById(R.id.textView)).setText("RGBWW LED - " + s);
    }

    private int getLEDBrightness(){
        int Brightness = 0;
        for (int i = 0; i < API.RGBWWControl.LEDCount; i++) {
            Brightness += ledPWMValue_SeekBar[i].getProgress();
        }
        return (Brightness /  API.RGBWWControl.LEDCount) * 100 / (API.RGBWWControl.PWM_Max - API.RGBWWControl.PWM_Min);
    }

    //endregion
}
