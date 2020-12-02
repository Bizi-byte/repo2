#include "Arduino.h"
#include <string.h>
#include "code_enterer.h"

namespace IP
{
code_enterer::code_enterer(int pin_num, const char* user_code,
                          unsigned int enter_time,  unsigned int blink_duration) 
  : keypad(Keypad(makeKeymap(keys), rowPins, colPins, ROWS, COLS)),
    m_led(pin_num), m_enter_time(enter_time), m_blink_duration(blink_duration),
    code_counter(enter_time), led_counter(blink_duration)
{ 
  InitCode(user_code);
}

void code_enterer::PrintStatus()
{
  Serial.println();
  Serial.println(state);
  // Serial.println(led_on);
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
        m_led.Switch();
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
    m_led.On();
  case ENTERING:
    entered[key_idx] = curr_key;
    ++key_idx;
    PrintStatus();

    if(key_idx >= code_len)
    {
      if(EnteredIsSame())
      {
        m_led.On();
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

void code_enterer::CodeCounterReset()
{
  code_counter = m_enter_time;
}
void code_enterer::LedCounterReset()
{
  led_counter = m_blink_duration;
}

void code_enterer::Reset() 
{ 
  m_led.Off();
  CodeCounterReset();
  LedCounterReset();
  state = START;
  key_idx = 0;
}
bool code_enterer::EnteredIsSame() const
{
  return (!memcmp(code, entered, code_len * sizeof(char)));
};

void code_enterer::InitCode(const char user_code[code_len])
{
  memcpy(code, user_code, sizeof(char) * code_len);
}
} // namespace IP
