  // Grove - EMG Sensor demo code
// This demo will need a Grove - Led Bar to show the motion 
// Grove - EMG Sensor connect to A0
// Grove - LED Bar connect to D8, D9
// note: it'll take about serval seconds to detect static analog value
// when you should hold your muscle static. You will see led bar from level 10 turn to 
// level 0, it means static analog value get ok

int max_analog_dta      = 700;              // max analog data
int min_analog_dta      = 100;              // min analog data
int static_analog_dta   = 0;                // static analog data

const int L1 = 2; // broche 2 du micro-contrôleur se nomme maintenant : L1
const int L2 = 4;


// get analog value
int getAnalog(int pin)
{

    long sum = 0;
    
    for(int i=0; i<32; i++)
    {
        sum += analogRead(pin);
    }
    
    int dta = sum>>5;
    
    max_analog_dta = dta>max_analog_dta ? dta : max_analog_dta;         // if max data
    min_analog_dta = min_analog_dta>dta ? dta : min_analog_dta;         // if min data
    
    return sum>>5;
  
    //return analogRead(pin);
}

void setup()
{
    Serial.begin(115200);
    pinMode(L1, OUTPUT); //L1 est une broche de sortie
    pinMode(L2, OUTPUT); //L1 est une broche de sortie
    long sum = 0;

    for(int i=0; i<=10; i++)
    {
        for(int j=0; j<100; j++)
        {
            sum += getAnalog(A0);
            delay(1);
        }
        
        //bar.setLevel(10-i);
    }
    
    sum /= 1100;
    
    static_analog_dta = sum;

    Serial.print("static_analog_dta = ");
    Serial.println(static_analog_dta);
}

void loop()
{

    int val = getAnalog(A0);                    // get Analog value
   
    Serial.println(val);
    
    if(val > 315)
    {
      Bouton();
      //Serial.println("Xobx powers activate");
    }

}


/*Cette fonction permet d'ordoner à l'Arduino d'appuyer sur 
 * un bonton de la manette
 * */
void Bouton()
{
  unsigned long start = millis();

  /*
   * Il faut envoyer un signal pendant un certain laps de temps
   * pour que la manette "comprenne" que l'on souhaite appuyer.
   * La durée idéale de cet intervelle reste à déterminer.
   */
   
  while(millis() < start + 75)
  {
    digitalWrite(L1, HIGH); //allumer L1
    digitalWrite(L2, HIGH); //allumer L1
  
    digitalWrite(L1, LOW); // Eteindre L1
    digitalWrite(L2, LOW); // Eteindre L1
  }


}
