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
  - [x] If enemy bullet collides with player bullet, set both inactive
  - [ ] Sprite
- [x] Score
  - [x] 100 points per enemy hit
- [x] Enemies
  - [x] Sprite
- [x] Character
  - [x] Sprite

## Nice to Have
- [ ] Enemy
  - [ ] Sprite Animation
  - [ ] Difficulty Settings
    - [ ] Enemy Bullet Speeds
    - [ ] Player Bullet Speed
    - [ ] Enemy Movement Speed

<br />


# AI

## Necessary Polish
- [x] Enemies
  - [x] AI Movement
  - [x] Detect when at edge of screen

<br />



# UI

## Worst Case Scenario (Need to Ship)
- [x] Lives

## Necessary Polish
- [x] Score
  - [x] 100 points per enemy hit
- [x] SceneHandler Script
  - [x] LoadScene()
  - [x] ExitGame()
- [x] Main Menu Scene
  - [x] "Play" Button
  - [x] "Exit" Button
- [x] Game Scene
  - [x] "Main Menu" / "Home" Button

<br />
