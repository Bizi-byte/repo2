#ifndef __LED_H__
#define __LED_H__

#include "Arduino.h"

namespace IP
{
class Led
{
public:
  explicit Led(int led_pin);
  ~Led() = default;
  Led(const Led& other) = default;
  Led& operator=(const Led& other) = default;
  
  int On();
  int Off();
  int Switch();
private:
  bool m_is_on = false;
  int m_led_pin;
};
  
} // namespace IP


#endif /* __LED_H__ */