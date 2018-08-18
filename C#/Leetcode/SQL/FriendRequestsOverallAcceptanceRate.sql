-- Leetcode 597

-- Question: https://code.dennyzhang.com/friend-requests-i-overall-acceptance-rate
-- TODO: Check if this is syntactically valid in SQL.

-- Solution1: Simplified version
select iif(totalrequests = 0, 0.00, round(totalaccepted/totalrequests, 2))
from (
		select count(distinct sender_id,send_to_id) as totalrequests
		from friend_request,	  
		select count(distinct requester_id,accepter_id) as totalaccepted
		from request_accepted  
	)


-- Solution 2
select iif(totalrequests = 0, 0.00, round(totalaccepted/totalrequests, 2))
from (
	select count(*) as totalrequests
	from (
			select distinct sender_id
					,send_to_id
			from friend_request
		  ),
	select count(*) as totalaccepted
	from (
			select distinct requester_id
					,accepter_id
			from request_accepted
		  )
	 )