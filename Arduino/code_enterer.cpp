#include "Arduino.h"
#include <string.h>
#include "code_enterer.h"


code_enterer::code_enterer(int pin_num, const char* user_code) 
  : keypad(Keypad(makeKeymap(keys), rowPins, colPins, ROWS, COLS)),
    led_pin(pin_num)
{
  pinMode(led_pin, OUTPUT);
  digitalWrite(led_pin, LOW);
  InitCode(user_code);
  // Serial.begin(9600);  
}

void code_enterer::PrintStatus()
{
  Serial.println();
  Serial.println(state);
  Serial.println(led_on);
  Serial.println(code_counter);
  Serial.println(led_counter);
  Serial.println(key_idx);
  PrintEntered();
}
void code_enterer::PrintEntered()
{
  for(int i = 0; i < code_len; ++i)
  {
    Serial.print(entered[i]);
  }
  Serial.println();
}
bool code_enterer::Check()
{
  curr_key = keypad.getKey();
  return (curr_key);
}
int code_enterer::Routine()
{
  if (state == ENTERING)
    {
      --led_counter;
      if(0 == led_counter)
      {
        SwitchLed();
        LedCounterReset();
      }
      --code_counter;
      if(code_counter == 0)
      {
        Reset();
      }
    }
}
int code_enterer::Run()
{
  switch (state)
  {
  case END:
    if(curr_key == '#')
    {
      Reset();
    }
    break;

  case START:
    state = ENTERING;
    LedOn();

  case ENTERING:
    entered[key_idx] = curr_key;
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
    break;

  default:
    break;
  }
}

void code_enterer::LedOn()
{
  digitalWrite(led_pin, HIGH);
  led_on = true;

} 
void code_enterer::LedOff()
{
  digitalWrite(led_pin, LOW);
  led_on = false;

}
void code_enterer::SwitchLed() 
{ 
  led_on ? LedOff() : LedOn();
}

void code_enterer::CodeCounterReset()
{
  code_counter = enter_time;
}
void code_enterer::LedCounterReset()
{
  led_counter = blink_duration;
}

void code_enterer::Reset() 
{ 
  LedOff();
  CodeCounterReset();
  LedCounterReset();
  state = START;
  key_idx = 0;
}
bool code_enterer::EnteredIsSame() const
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

void code_enterer::InitCode(const char user_code[code_len])
{
  memcpy(code, user_code, sizeof(char) * code_len);
}
