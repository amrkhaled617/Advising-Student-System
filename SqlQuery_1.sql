
declare @id int --point 1
Exec Procedures_StudentRegistration	'Ahmed','Hassan','pass','MET','Ahmed.example@gmail.com','Engineering',2,@id
print @id 
insert into Stud
--we need to set the financial status to one 
update Student --- students should adjust this 
set financial_status = 1 
where student_id = 1


--admin login hardcoded --point 4 


Exec Procedures_AdminAddingCourse 'Enginerring',2,4,'CSEN202',1 --point 6 
insert into Instructor_Course values(4,1) -- if their code handles this no need else students should adjust this 
Exec Procedures_AdminLinkInstructor 4,1,1 --point 7 
Exec Procedures_AdvisorRegistration 'Ali','pass','Ali.a@example.com','C6.206',@id
print @id
print(dbo.FN_AdvisorLogin(1,'pass')) --point 9





Exec Procedures_ViewOptionalCourse 1,'S24' --point 15

Exec Procedures_ViewRequiredCourses 1,'S24' --point 16

Exec Procedures_StudentSendingCourseRequest 1,1,'courseRequest','comment' --point 17

Exec Procedures_StudentSendingCHRequest 1,3,'creditHours','comment' --point 18

select * from all_Pending_Requests --point 19

update Student --- students should adjust this 
set assigned_hours=25,acquired_hours=180
where student_id=1

select * from student
select * from request
select * from Student_Instructor_Course_take


Exec Procedures_AdvisorApproveRejectCourseRequest 1,'S24'  -- accept --point 20

update Student ---- students should adjust this 
set gpa=2
where student_id=1

Exec Procedures_AdvisorApproveRejectCHRequest 2,'S24' -- accept --point 21


Exec Procedures_AdvisorCreateGP 'S24','11-11-2028',22,1,1 --point 22

Exec Procedures_AdvisorAddCourseGP 1,'S24','CSEN104' --point 23

select * from Graduation_Plan
select * from GradPlan_Course
Exec Procedures_AdminDeleteCourse 3 --point 24

Exec Procedures_AdminAddExam 'First_makeup','11-4-2024',1 --point 25

Insert into Payment values(1,100000,'3/1/2024','6/30/2024',2,0,null,1,'S24' )---- students should adjust this 

select * from Student_Payment --point 26


Exec Procedures_AdminIssueInstallment 1 --point 27


select * from dbo.FN_StudentViewGP(1) --point 28

print(dbo.[FN_StudentUpcoming_installment](1)  ) -- point 29

select * from Courses_MakeupExams --point 30

update Student_Instructor_Course_take --- students should adjust this 
set grade = 'F'
where student_id = 1 and course_id = 1
Exec Procedures_StudentRegisterFirstMakeup 1,1,'S24' -- point 31 --- should register 

update Student_Instructor_Course_take  --- students should adjust this 
set grade = 'F' 
where semester_code = 'S24'

update Student_Instructor_Course_take   --- students should adjust this 
set exam_type = 'Normal'
where semester_code = 'S24'

select * from Student_Instructor_Course_take 
select * from Exam_Student

insert into Student_Instructor_Course_take values (1,2,null,'S24','Normal','F') --- students should adjust this 
Exec Procedures_StudentRegisterSecondMakeup 1,1,'S24' --point 32    --  should not register 
select * from Student


update Installment --- students should adjust this 
set deadline = '2023-9-01' 
where deadline = '2024-04-01 00:00:00.000' and payment_id = 1
Exec Procedure_AdminUpdateStudentStatus 1 --point 33  --should make student financial = 0

select * from Advisors_Graduation_Plan  ---point 34

select * from  Students_Courses_transcript  ---point 35










