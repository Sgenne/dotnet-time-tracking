import { ChangeEventHandler } from "react";
import { getInputChangeHandler } from "../../../utils/adapters/InputElementChangeAdapter";

export interface ClearTextInputProps {
  onChange: (value: string) => void;
  value: string;
}

const ClearTextInput = ({ onChange, value }: ClearTextInputProps) => {
  const changeHandler: ChangeEventHandler<HTMLInputElement> =
    getInputChangeHandler(onChange);

  return <input value={value} onChange={changeHandler} />;
};

export default ClearTextInput;
