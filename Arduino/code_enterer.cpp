#include "Arduino.h"
#include <string.h>
#include "code_enterer.h"


code_enter::code_enter(int pin_num, const char* user_code) 
  : keypad(Keypad(makeKeymap(keys), rowPins, colPins, ROWS, COLS)),
    led_pin(pin_num)
{
  pinMode(led_pin, OUTPUT);
  digitalWrite(led_pin, LOW);
  InitCode(user_code);
  // Serial.begin(9600);  
}

void code_enter::PrintStatus()
{
  Serial.println();
  Serial.println(state);
  Serial.println(led_on);
  Serial.println(code_counter);
  Serial.println(led_counter);
  Serial.println(key_idx);
  PrintEntered();
}
void code_enter::PrintEntered()
{
  for(int i = 0; i < code_len; ++i)
  {
    Serial.print(entered[i]);
  }
  Serial.println();
}
void code_enter::Run()
{
  if(state != END)
  {
    char key = keypad.getKey();
    if(key)
    {
      if(state == START)
      {
        state = ENTERING;
        LedOn();
      }
      entered[key_idx] = key;
      ++key_idx;
      PrintStatus();

      if(key_idx >= code_len)
      {
        if(EnteredIsSame())
        {
          LedOn();
          state = END;
        }
        else
        {
          Reset();
        } 
      }
    }
    if (state == ENTERING)
    {
      --code_counter;
      --led_counter;
      if(0 == led_counter)
      {
        SwitchLed();
        LedCounterReset();
      }
    }
    if(code_counter == 0)
    {
      Reset();
    }
  }
  else
  {
    char key = keypad.getKey();
    if(key == '#')
    {
      Reset();
    }
  }
}
void code_enter::LedOn()
{
  digitalWrite(led_pin, HIGH);
  led_on = true;

} 
void code_enter::LedOff()
{
  digitalWrite(led_pin, LOW);
  led_on = false;

}
void code_enter::SwitchLed() 
{ 
  led_on ? LedOff() : LedOn();
}

void code_enter::CodeCounterReset()
{
  code_counter = enter_time;
}
void code_enter::LedCounterReset()
{
  led_counter = blink_duration;
}

void code_enter::Reset() 
{ 
  LedOff();
  CodeCounterReset();
  LedCounterReset();
  state = START;
  key_idx = 0;
}
bool code_enter::EnteredIsSame() const
{
  size_t i = 0;
  for (i = 0; i < code_len; ++i)
  {
    if(code[i] != entered[i])
    {
      return false;
    }
  }
  return true;
};

  void code_enter::InitCode(const char user_code[code_len])
  {
    memcpy(code, user_code, sizeof(char) * code_len);
  }
