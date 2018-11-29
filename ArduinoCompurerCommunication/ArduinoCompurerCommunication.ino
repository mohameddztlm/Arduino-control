
String listON[]={ "ON2", "ON3", "ON4", "ON5", "ON6", "ON7", "ON8", "ON9", "ON10", "ON11", "ON12", "ON13" };
String listOFF[]={ "OFF2", "OFF3", "OFF4", "OFF5", "OFF6", "OFF7", "OFF8", "OFF9", "OFF10", "OFF11", "OFF12", "OFF13" };

void setup(){
  Serial.begin(9600); 
  pinMode(0,OUTPUT);
  pinMode(1,OUTPUT);
  pinMode(2,OUTPUT);
  pinMode(3,OUTPUT);
  pinMode(4,OUTPUT);
  pinMode(5,OUTPUT);
  pinMode(6,OUTPUT);
  pinMode(7,OUTPUT);
  pinMode(8,OUTPUT);
  pinMode(9,OUTPUT);
  pinMode(10,OUTPUT);
  pinMode(11,OUTPUT);
  pinMode(12,OUTPUT);
  pinMode(13,OUTPUT);
}
void loop(){
  String readString,varible;
  while(Serial.available()){
    delay(1);
    if(Serial.available()>0){
      char c=Serial.read();
      if(isControl(c))
      {
        break;
      }
      readString+=c;
    }
  }
varible=readString;
int i;

for(i=1;i<15;i++){
  if(varible==listON[i]){
    digitalWrite(i,HIGH);
  }
  else if(varible==listOFF[i]){
    digitalWrite(i,LOW);
  }

else if(varible=="OFFALL")
{
  PORTD=0;
  PORTB=0;
}
}
varible="";
}
