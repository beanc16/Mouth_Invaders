<!-- TABLE OF CONTENTS -->
<details open="open">
  <h1>Table of Contents</h1>
  <ol>
    <li>
      <a href="#gameplay">Gameplay</a>
    </li>
    <li>
      <a href="#ai">AI</a>
    </li>
    <li>
      <a href="#ui">UI</a>
    </li>
  </ol>
</details>
<br />


# Gameplay

## Worst Case Scenario (Need to Ship)
- [x] Character
  - [x] Move
  - [x] Shoot a Bullet
  - [x] Collision/Trigger Detection (for enemy bullets)
  - [x] Lives
- [x] Bullet
  - [x] Movement
  - [x] Went off screen
  - [x] Collision/Trigger Detection
    - [x] Hit Enemy
    - [x] Hit Player
- [x] Enemies
  - [x] Collision/Trigger Detection
  - [x] Fire Bullets Randomly
- [x] States
  - [x] Win State
  - [x] Lose State

## Necessary Polish
- [ ] Bullet
  - [ ] If enemy bullet collides with player bullet, set both inactive
  - [ ] Sprite
- [ ] Score
  - [ ] 100 points per enemy hit
- [ ] Enemies
  - [ ] Sprite
- [ ] Character
  - [ ] Sprite

## Nice to Have
- [ ] Enemy
  - [ ] Sprite Animation
  - [ ] Difficulty Settings
    - [ ] Enemy Bullet Speeds
    - [ ] Player Bullet Speed
    - [ ] Enemy Movement Speed

<br />


# AI

## Worst Case Scenario (Need to Ship)

## Necessary Polish
- [ ] Enemies
  - [ ] AI Movement
  - [ ] Detect when at edge of screen

## Nice to Have

<br />



# UI

## Worst Case Scenario (Need to Ship)
- [x] Lives

## Necessary Polish
- [ ] Score
  - [ ] 100 points per enemy hit
- [ ] SceneHandler Script
  - [ ] LoadScene()
  - [ ] ExitGame()
- [ ] Main Menu Scene
  - [ ] "Play" Button
    - [ ] Layout
    - [ ] Functionality
  - [ ] "Exit" Button
    - [ ] Layout
    - [ ] Functionality
- [ ] Game Scene
  - [ ] "Main Menu" / "Home" Button
    - [ ] Layout
    - [ ] Functionality

## Nice to Have
- [ ] SceneHandler Script
  - [ ] RestartScene()

<br />
