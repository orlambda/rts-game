- Click manager
    - Add colliders ground, buildings, and units
    - Detect clicks in ClickManager.cs
    - My guess at what to do:
        - add OnClick function to clickable objects
        - add test e.g. move on click

- Classes / inheritance
    - Entities / objects - naming?
        Is destroyed when HP is 0
        bool can be clicked
        bool can be multiselected
        bool included in dragbox?
        - Buildings
        - Harvestables
        - Units
    - Players
        bool: alive/stillPlaying
        ID
        score?
        resources
        kills / other stats
        human or AI
    - functional / management
        - clicks
        - movement
        - selection