import { useState } from "react";
import ControlledStateHandler from "../types/ControlledStateHandler";
import OnStringChange from "../types/OnStringChange";

const useStringInput = (initialValue = ""): ControlledStateHandler<string> => {
  const [value, setValue] = useState(initialValue);

  const changeHandler: OnStringChange = (newValue: string) =>
    setValue(newValue);

  return {
    value,
    changeHandler,
  };
};

export default useStringInput;
