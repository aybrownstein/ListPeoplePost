$(() => {
    let counter = 1;
    $("#add-row").on('click', function () {
        $("#add-people-rows").append(`<div class="col-md-4">
                <input class="form-control" type="text" name="people[${counter}].firstName" placeholder="First Name" />
            </div>
            <div class="col-md-4">
                <input class="form-control" type="text" name="people[${counter}].lastName" placeholder="Last Name" />
            </div>
            <div class="col-md-4">
                <input class="form-control" type="text" name="people[${counter}].age" placeholder="Age" />
            </div>`)
        counter++;
    });
});