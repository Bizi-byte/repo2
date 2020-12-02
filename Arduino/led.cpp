
#include "Arduino.h"
#include "led.h"

namespace IP
{
Led::Led(int led_pin) : m_led_pin(led_pin)
{
  pinMode(led_pin, OUTPUT);
  digitalWrite(led_pin, LOW);
}

int Led::On()
{
  digitalWrite(m_led_pin, HIGH);
  m_is_on = true;

  return (0);
} 

int Led::Off()
{
  digitalWrite(m_led_pin, LOW);
  m_is_on = false;

  return (0);
}

int Led::Switch() 
{ 
  m_is_on ? Off() : On();

  return (0);
}
  
} // namespace IP
