<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a id="readme-top"></a>


<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/lawtancool/Cooked">
    <img src="docs/favicon/favicon.svg" alt="Logo" width="100" height="100">
  </a>

<h3 align="center">Cooked</h3>

  <p align="center">
    A co-located multiplayer AR experience for Meta Quest 3
    <br />
    <!-- <a href="https://lawtancool.github.io/Cooked"><strong>Project website »</strong></a> -->
    <!-- <br /> -->
    <br />
    <a href="https://lawtancool.github.io/Cooked">Project Website</a>
    &middot;
    <a href="https://github.com/lawtancool/Cooked/blob/main/docs/images/Cooked.pdf">Poster (PDF)</a>
    &middot;
    <a href="https://www.youtube.com/watch?v=47_7hhijdsE">Demo Video</a>
  </p>
</div>



<!-- ABOUT THE PROJECT -->
## About The Project

Inspired by the hit game *Overcooked!*, *Cooked* is the world's first co-located multiplayer cooking game developed for an augmented reality (AR) headset. Using Meta Quest 3 headsets, multiple players can work together to cook as many steaks as possible before time runs out! 

*Cooked* is a co-located experience, meaning players see and interact with each other while standing in the same real-world space. Players can hand off steaks to each other using their hands, or throw them across the room for their teammates to catch out of the air. 

*Cooked* uses the latest Meta Quest 3 AR capabilities to make  game objects blend seamlessly with reality. Scene understanding allows steaks to fall onto the floor, bounce off the walls, and cast simulated shadows onto the real world. Real-time depth mapping allows real-world objects like as furniture and people to appear in front of virtual objects, blocking their view as if the virtual objects were truly situated in the room. 

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Demo Video
_(Click image to go to the video on YouTube)_

[![Demo Video Link](https://img.youtube.com/vi/47_7hhijdsE/0.jpg)](https://www.youtube.com/watch?v=47_7hhijdsE)
<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Built With

| Unity 6 | Photon Fusion 2 | Meta XR Building Blocks |
|:--:|:--:|:--:|
| [<img src="docs/images/unity.png" alt="Unity" width="200" />](https://docs.unity3d.com/Manual/index.html) | [<img src="docs/images/photon.png" alt="Photon" width="150" />](https://doc.photonengine.com/fusion/current/) | [<img src="docs/images/meta-quest-3.png" alt="Meta Quest 3" width="200" />](https://developers.meta.com/horizon/documentation/unity/bb-multiplayer-blocks) |

### Meta XR Building Blocks Used
- [Multiplayer Building Blocks](https://developers.meta.com/horizon/documentation/unity/bb-multiplayer-blocks)
    - *Local Matchmaking:* joins headsets to the same multiplayer room using Bluetooth discovery
    - *Shared Spatial Anchor Core:* uses camera data to creates shared points of reference, allowing multiple headsets to understand their relative positions in a shared physical space
    - *Colocation:* connects Shared Spatial Anchors to the Photon Fusion multiplayer system to enable colocated experiences
    - *Player Name Tag:* adds name tags above other players, useful for determining if colocation is active
- Augmented Reality (AR) Capabilities
    - [*Passthrough*](https://developers.meta.com/horizon/documentation/unity/unity-passthrough-tutorial-with-blocks/): Provides camera feed to allow players to see the real world
    - [*Occlusion*](https://developers.meta.com/horizon/documentation/unity/unity-depthapi-occlusions-get-started): Allows real-world objects such as other people to appear in front of virtual objects, creating a realistic sense of depth.
    - [*MRUK Scene API*](https://developers.meta.com/horizon/documentation/unity/unity-mr-utility-kit-overview): Provides scene understanding to allow virtual objects to fall and bounce off real-world walls, floors, and furniture.
    - [*MRUK Passthrough Relighting*](https://developers.meta.com/horizon/documentation/unity/unity-passthrough-relighting): Uses scene understanding to allow virtual objects to cast shadows and light on the real world.
- [Spatial Audio](https://developers.meta.com/horizon/documentation/unity/meta-xr-audio-sdk-unity): Allows game sounds to be perceived as coming from different directions as the player moves around the environment.



<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

This project was produced using two Meta Quest 3 headsets loaned from the University of Washington during the CSE 493V VR Systems course. We thank Douglas Lanman and John Akers for their support during the course!

<p align="right">(<a href="#readme-top">back to top</a>)</p>
