import React from "react";

const TestCreate = ({ user, addTest }) => {
  const handleSubmit = (e) => {
    e.preventDefault();
    const { value } = e.target.elements.name;
    const test = { name: value };

    const createTest = async () => {
      const requestOptions = {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(test),
      };

      const response = await fetch("api/Test", requestOptions);
      return await response.json().then(
        (data) => {
          console.log(data);
          if (response.ok) {
            addTest(data);
            e.target.elements.name.value = "";
          }
        },
        (error) => console.log(error)
      );
    };
    createTest();
  };

  return (
    <React.Fragment>
      {user.isAuthenticated ? (
        <>
          <h3>Create new text</h3>
          <form onSubmit={handleSubmit}>
            <label>Test name: </label>
            <input type="text" name="name" placeholder="Enter text:" />
            <button type="submit">Create</button>
          </form>{" "}
        </>
      ) : (
        ""
      )}
    </React.Fragment>
  );
};

export default TestCreate;
