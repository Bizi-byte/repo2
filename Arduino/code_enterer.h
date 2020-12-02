/*************************
 * class definition for code enterer in arduino
 * author: Yishai Peleg
 * date: 1/12/2020
 * ***********************/

#ifndef __CODE_ENTERER_H__
#define __CODE_ENTERER_H__

#include <Keypad.h>
#include "Arduino.h"
#include "led.h"

namespace IP
{
typedef enum states
{
  START,
  ENTERING,
  END,
}enter_state;

class code_enterer
{
public:
  explicit code_enterer(int pin_num, const char *user_code,
                        unsigned int enter_time,  unsigned int blink_duration);
  ~code_enterer() = default;
  code_enterer(code_enterer& other) = delete;

  bool Check();
  int Run();
  int Routine();

  void PrintStatus();
  void PrintEntered();

  static const unsigned char code_len = 4;
private:
  void CodeCounterReset();
  void LedCounterReset();
  void Reset();
  bool EnteredIsSame() const;

  char curr_key = 0;
  unsigned char key_idx = 0;
  char code[code_len] = {-1};
  char entered[code_len] = {-1};

  const unsigned int m_enter_time;
  const unsigned int m_blink_duration;

  unsigned int code_counter;
  unsigned int led_counter;

  void InitCode(const char user_code[code_len]);

  IP::Led m_led;
  enter_state state = START;
  static const byte ROWS = 4; //four rows
  static const byte COLS = 4; //three columns
  char keys[ROWS][COLS] = {
                            {'1','2','3', 'A'},
                            {'4','5','6', 'B'},
                            {'7','8','9', 'C'},
                            {'*','0','#', 'D'}
                          };
  byte colPins[ROWS] = {5, 4, 3, 2}; //connect to the row pinouts of the keypad
  byte rowPins[COLS] = {9, 8, 7, 6}; //connect to the column pinouts of the keypad
  Keypad keypad;
};
} // namespace IP

#endif // __CODE_ENTERER_H__