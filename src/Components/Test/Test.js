import React, { useEffect } from "react";
import "./Style.css";

const Test = ({ user, tests, setTests, removeTest }) => {
  /*const handleSubmit = (e) => {
    e.preventDefault();
    const { value } = e.target.elements.name;
    const { valueId } = e.target.elements.id;
    const test = { id: valueId, name: value };
    const updateItem = async ({ id }) => {
      const requestOptions = {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(test),
      };
      const response = await fetch(
        "api/Test/" + new URLSearchParams({ id }).toString(),
        requestOptions
      );
      return await response.json().then(
        (data) => {
          console.log(data);
          if (response.ok) {
            updateTest(data);
            e.target.elements.name.value = "";
          }
        },
        (error) => console.log(error)
      );
    };
    updateItem(valueId);
  }*/

  useEffect(() => {
    const getAllTests = async () => {
      const requestOptions = {
        method: "GET",
      };
      return await fetch("api/Test/list", requestOptions)
        .then((Response) => Response.json())
        .then(
          (data) => {
            console.log("Data:", data);
            setTests(data);
          },
          (error) => {
            console.log(error);
          }
        );
    };
    getAllTests();
  }, [setTests]);

  const deleteItem = async ({ id }) => {
    const requestOptions = {
      method: "DELETE",
    };
    return await fetch(
      "api/Test/" + new URLSearchParams({ id }).toString(),
      requestOptions
    ).then(
      (Response) => {
        if (Response.ok) {
          removeTest(id);
        }
      },
      (error) => console.log(error)
    );
  };

  return (
    <React.Fragment>
      <h1>List of Tests</h1>
      {tests.map(({ id, name, questions }) => (
        <div className="Test" key={id} id={id}>
          <strong>
            {" "}
            {id}:{name}{" "}
          </strong>
          {user.isAuthenticated ? (
            <>
              <button onClick={() => deleteItem({ id })}>Delete</button>
            </>
          ) : (
            ""
          )}
          {questions.map(({ questionId, text }) => (
            <div className="TestElement" key={questionId} id={questionId}>
              {text}
            </div>
          ))}
        </div>
      ))}
    </React.Fragment>
  );
};
export default Test;
