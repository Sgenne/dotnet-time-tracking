import { ChangeEventHandler } from "react";
import { getInputChangeHandler } from "../../../utils/adapters/InputElementChangeAdapter";
import TextInputProps from "../../../types/InputProps";
import StandardStyles from "../../../styles/utils/input/TextInput.module.css";

export type GenericTextInputProps = TextInputProps & {
  styles: { [key: string]: string };
};

const TextInput = ({ onChange, value, styles }: GenericTextInputProps) => {
  const changeHandler: ChangeEventHandler<HTMLInputElement> =
    getInputChangeHandler(onChange);

  return (
    <div className={StandardStyles["input-container"]}>
      <input value={value} onChange={changeHandler} />
    </div>
  );
};

export default TextInput;
