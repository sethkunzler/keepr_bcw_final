To Do's 

High Fidelity Mock: 
  [https://www.figma.com/proto/5ImMGVfWaUJwSYLU4xscBk/Keepr?scaling=scale-down&page-id=0%3A1&starting-point-node-id=7786%3A144&node-id=7786-144]
Uml: 
  [https://www.figma.com/file/0Oh881I5ZW18gOj9DmmRdS/Keepr-%F0%9F%8F%81?type=whiteboard&node-id=0-1&t=Lm7bMzbe0JXijSPw-0]

PLAN: 
Friday - 8hrs
12:00 - 12:30 - setting up auth and env and plan ✅
plan
1:30 - 4:00 - BE: passing first couple of postman tests Keeps: create and get ✅
4:00 - 5:00 - FE: getting and creating keeps  ✅

7:00 - 9:00 - BE: Put and Delete Keeps ✅

Saturday - 3hrs
7:00 - 8:30 - FE: put and Delete keeps ✅
9 --- Breakfast and travel
10-12 --- General Conference
12-1 ---Lunch
1:00 - 2:00 BE: Create Vault ✅
2-4 --- General Conference
4:00 - 5:00 - BE: Get Vault ✅
6-7 --- Dinner
6-8 --- General Conference 
8-9 --- Chilling & going home

Sunday 4hrs
7:00 - 8:30 - FE: Get Vault ✅
9-10 --- Breakfast & heading out
10-12 --- General Conference
12-1 ---Lunch 
1:00 - 2:00 - FE: Create Vault 🟨 (is Private defaults false)
2-4 --- General Conference 
4:00 - 5:00 BE: Vault Keeps - Post ❌
5-6 --- Dinner
6-8 --- Chilling & going home 
8:00 - 9:00 - BE: get Vault Keeps ❌


Monday 9hrs
*** 7:00 - 7:30  revaluate where I am at and create the plan for the rest of the week.
9:00 - 12:30 BE: Put and Delete Keeps. FE: Put and Delete Keeps ✅
1:30 - 5:00 BE: Create and Get Vaults. FE: Getting Vaults ✅
7:00 - 9:00 FE: Creating Vaults BE: Editing Vaults ✅

Tuesday 9hrs
9:00 - 12:30 BE: Deleting Vaults; FE: Editing and Deleting Vaults; BE: Post Vault Keeps ❌
1:30 - 5:00 BE: Get Vault Keeps; FE: Get and create Vault Keeps; BE: Delete Vault Keeps ❌
7:00 - 9:00 FE: Delete Vault Keeps ❌

Wednesday Morning
9:00 - 9:00 **FIRST GRADING** After 35 scheduled hours

Wednesday 8hrs
9:00 - 12:30 BE: All Gets by Profile Id, Get vaults by AccountId, 
1:30 - 5:00 FE: Items display to their proper pages.
7:00 - 9:00 BE: No-Auth Tests, starting on InvalidAuth Tests

Thursday Morning 4hrs
7:00 - 7:30 Revaluate My Plan
9:00 - 12:30 {To PLAN}
** (( Plan to be done by this point ))

Thursday Afternoon 3hrs
1:30 - 4:00 {To PLAN}
4:00 - 5:00 **SECOND GRADING** after 46 scheduled hours

Thursday Night 2hrs
7:00 - 9:00 {To PLAN}

Friday 7hrs
9:00 - 12:30 {To PLAN}
1:30 - 4:00 {To PLAN}
4:00 - 5:00 **LAST GRADING** after 55 scheduled hours

enjoy te weekend

Actual - 
TOTAL HOURS:

Friday 8hrs
12:00 - 12:30 Plan (Through Sunday), and env Setup 
1:30 - 4:00 BE: Postman: Valid Auth> Keep> Post, GetAll, GetById
4:00 - 5:30 FE: getting keeps, some styling, Header
8:00 - 10:30 FE: creating keeps, some styling, some accessibility, Footer

Saturday 3hrs
7:30 - 9:00 - Setting up a display modal
12:00 -1:00 - getting keep by Id
4:00 - 5:00 - Setting up an Active Details modal made it components 

Sunday 
No effective progress made.

Monday 9hrs
7:00 - 7:30 - Plan through Wednesday.
9:00 - 12:30 - BE: Put and Delete Keeps. FE: Put Keeps
1:30 - 5:00 - FE: Delete Keeps; BE: Create; 
7:00 - 9:00 - BE: Get Vault By Id, Get Vaults by Profile; FE: Profile Page Setup

Tuesday 9hrs
9:00 - 12:00 - Fe: Getting Profile,  getting vaults by profile, 
1:00 - 5:00 - FE: Vaults Page Setup
7:30 - 9:30 - BE: Delete and Put Vaults, FE: Delete and Create Vaults

Wednesday 10hrs
9:00 - 12:00 - BE: KeepVaults and KeptKeep setup;
12:00 - 12:30 - **First Grading** After 32 hours
1:30 - 5:30 - BE: Get and Delete VaultKeeps, Get Keeps By Profile ID, Get Vaults for logged in user
7:30 - 10:30 - BE: Put Keep's Viewed Count, Kept Count -&+, Put Account, Get Keeps for logged in user


18 Requirements
✅🟨❌
  students may miss up to 2 and still be passing.
  🟨 - passing another requirement could cause this to fail - check again before grading

✅Users can Register, login and automatically authenticated on refresh

✅Visitors can see all keeps (login not required)
✅Clicking on a keep card opens the keep in a modal
✅Anytime a keeps details are viewed, the keeps view count is incremented

✅The Vault Page shows only the keeps in that Vault
❌On the Vault Page, users can remove keeps from their vaults
  -TODO - @Click
✅The user should be pushed back to the home page when they attempt to open a Vault Page for a vault they do not have access to
❌Users can Add keeps to vaults
  -TODO - FE: Form -multiSelect
  ❌Anytime a keep is kept in a vault the kept count is incremented
  -TODO - FE: Form

✅All users have a public profile page

✅The logged-in user can Create and Delete Keeps

✅The logged-in user can Create and Delete Vaults

❌The logged-in user can edit their account
  -TODO - FE: Form

Postman:
✅All No Auth API Tests pass
✅All Valid Auth API Tests pass
✅All Invalid Auth API Tests pass
  --🟨passing the invalid tests may cause the Valid Auth or No auth tests to fail

❌🟨The UI Meets mock requirements
  [https://www.figma.com/file/5ImMGVfWaUJwSYLU4xscBk/Keepr?type=design&node-id=0-1&mode=design&t=yrCS9uwidiqCLdDd-0]
  -Home Page Mobile: Keep cards following masonry layout with two 'columns' per 'row'.
  -Home Page: keep cards are displayed using a masonry layout.
    -Keep Card: keep's title and creator's picture displays on top of picture. Clicking on a card should open up a modal displaying the keep details.
    -Keep Card: Creator's picture should have a title tag displaying the creator's name.
      -Keep Details: Display the view count and kept count.
      -Keep Details: *If the user is logged in: modal has a dropdown of all the user's vaults. Selecting a vault should 'save' the keep, creating a many-to-many relationship between the vault and the saved keep.
  -Vault Page: Displays total amount of keeps in vault (vaultKeeps) and vault cover image. 
  -Vault Page: Display name of vault and creator name (and description)
  -Profile Page: Total number of vaults and keeps created by user is also displayed.
  -Account Page: The total number of vaults and keeps created by user account is displayed.
    -Vault Card: Displays the title of the vault on top of the image, as well as a style indication if the vault is private.

❌🟨UI adheres to all phases of CodeWorks Design Requirements
  [https://www.figma.com/file/E2d4iw2PVMeKrusC2KEJDW/CodeWorks-Design-Guide?type=design&node-id=243-1&mode=design&t=IgEPM6hYcRY7uVGL-0]
  -Lighthouse: Accessibility 95 or Higher
  -Lighthouse: Best Practices 80 or Higher
    -Aria IDs are not unique(my forms need new labels)
  -Looks good on Desktop and Mobile
  -Reactivity - changes to data do not require refresh
  -Forms - validated properly 
  -Hide Buttons when you shouldn't be able to use them 
    -(move them to the right page)

7 Stretch Goals - Not Required (goal: hit at least two)

❌Keeps should be tagged, allowing users find keeps by tag

❌Users can create custom tags

❌Tags are not duplicated (Games,games,GAMES)

❌Stretch Goal API tests pass

❌Implement pagination or infinite scroll

❌Users can extend their profile to include a bio, hobbies, ect...

❌Users can share to other popular social media