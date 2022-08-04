import Validator from "../../types/Validator";

const validateUsername: Validator<string> = (username: string) => {
  if (username.length < 3)
    return {
      isValid: false,
      message: "A username cannot be less than three characters long.",
    };

  if (username.indexOf(" ") !== -1)
    return {
      isValid: false,
      message: "A username cannot contain spaces.",
    };

  return {
    isValid: true,
    message: ""
  };
};
