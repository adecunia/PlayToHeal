const int L1 = 2; // broche 2 du micro-contrôleur se nomme maintenant : L1
const int L2 = 9;
void setup() //fonction d'initialisation de la carte
{
//contenu de l'initialisation
pinMode(L1, OUTPUT); //L1 est une broche de sortie
pinMode(L2, OUTPUT); //L1 est une broche de sortie
//digitalWrite(L1, LOW);
//digitalWrite(L2, LOW);
Serial.begin(9600);

 
}

void loop() //fonction principale, elle se répète (s’exécute) à l'infini
{
  /*
  digitalWrite(L1, HIGH); //allumer L1
    digitalWrite(L2, HIGH); //allumer L1
  delay(1000);
   digitalWrite(L1, LOW); // Eteindre L1
   digitalWrite(L2, LOW); // Eteindre L1
   */
  delay(3000);
  Bouton();
  
}

void Bouton()
{
  int start = millis();
  while(millis() < start + 75)
  {
    digitalWrite(L1, HIGH); //allumer L1
    digitalWrite(L2, HIGH); //allumer L1
  
    digitalWrite(L1, LOW); // Eteindre L1
    digitalWrite(L2, LOW); // Eteindre L1
  }
  //delay(200);

}
