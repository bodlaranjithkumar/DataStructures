-- Leetcode 602

-- Question: https://code.dennyzhang.com/friend-requests-ii-who-has-the-most-friends
-- TODO: Check if this is syntactically valid in SQL.

select top 1 accepter_id, count(*)
from request_accepted
group by accepter_id
