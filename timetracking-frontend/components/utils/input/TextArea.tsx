import { ChangeEvent, ChangeEventHandler } from "react";
import styles from "../../../styles/utils/input/TextArea.module.css";
import TextInputProps from "../../../types/InputProps";
import OnStringChange from "../../../types/OnStringChange";
 
const TextArea = ({ value, onChange }: TextInputProps) => {
  const changeHandler = getTextAreaChangeHandler(onChange)

  return <textarea className={styles["text-area"]} onChange={changeHandler}>
    {value}
  </textarea>
}

const getTextAreaChangeHandler =
  (onChange: OnStringChange): ChangeEventHandler<HTMLTextAreaElement> =>
    (e: ChangeEvent<HTMLTextAreaElement>) =>
      onChange(e.target.value);

export default TextArea